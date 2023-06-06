using MetroFramework.Forms;
using MetroFramework;
using System;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.IO;
using System.Text;
using Logging_Framework;
using System.Text.Json;
using System.Drawing;
using System.Collections.Generic;

namespace AEBFileDownloader
{
    public partial class Form1 : MetroForm
    {
        private DateTime objDateTime;

        public Form1()
        {
            InitializeComponent();
            ddlCustomsDeclaration.Items.Add("Select Declaration");
            ddlCustomsDeclaration.Items.Add("IMPORT_NL");
            ddlCustomsDeclaration.Items.Add("EXPORT_NL");
            ddlCustomsDeclaration.Items.Add("TRANSIT_NL");
            ResetControls();
        }
        private void ResetControls()
        {
            ddlDocumentType.Enabled = false;
            ddlDocumentType.Items.Clear();
            metroLabel4.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = @"C:\Users\USER\Downloads",
                    Title = "Browse CSV Files",
                    CheckFileExists = true,
                    CheckPathExists = true,
                    DefaultExt = "csv",
                    Filter = "csv files (*.csv)|*.csv",
                    RestoreDirectory = true,
                    ShowReadOnly = true
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtCsvFilePath.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ddlCustomsDeclaration_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ResetControls();
            switch (comboBox.SelectedIndex)
            {
                case 1:
                    ddlDocumentType.Items.AddRange(new string[] { "UTB", "WAYBILL" });
                    ddlDocumentType.Enabled = true;
                    break;
                case 2:
                    ddlDocumentType.Items.AddRange(new string[] { "EAD_NL", "POE_NL" });
                    ddlDocumentType.Enabled = true;
                    break;
                case 3:
                    ddlDocumentType.Items.AddRange(new string[] { "TAD_NL" });
                    ddlDocumentType.Enabled = true;
                    break;
                default:
                    break;
            }

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroButton2.Enabled = false;
            if (string.IsNullOrEmpty(txtCsvFilePath.Text))
            {
                MessageBox.Show(this, "Please select csv file.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                metroButton2.Enabled = true;
                return;
            }
            if (ddlDocumentType.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select document type.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                metroButton2.Enabled = true;
                return;
            }
            if (ddlCustomsDeclaration.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select customer Declaration.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                metroButton2.Enabled = true;
                return;
            }
            try
            {
                Parser parser = new Parser();
                var iniData = parser.Parse();
                if (iniData != null)
                {
                    RequestModel requestModel = new RequestModel();
                    ReadIniFile(iniData, requestModel);


                    string saveDownloadsFolderPath = iniData["Settings"]["SaveFileFolder"];
                    string logsFolder = iniData["Settings"]["LogFolder"];
                    Logging_Framework.Logger logger = Logger.GetLogger(logsFolder, iniData["Settings"]["LogLevel"]);
                    ApiCalls apiCalls = new ApiCalls(logger);
                    var taskUserLogon = apiCalls.LogonUser(requestModel);
                    if (taskUserLogon == null)
                    {
                        MessageBox.Show(this, "Login Error. Please see logs for details.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        metroButton2.Enabled = true;
                        return;
                    }

                    while (!taskUserLogon.IsCompleted)
                        Thread.Sleep(100);

                    if (taskUserLogon.IsCompleted)
                    {
                        var responseUserLogon = taskUserLogon.Result;
                        logger.Log(LogLevels.Debug, JsonSerializer.Serialize(responseUserLogon));
                        if (responseUserLogon.error == null)
                        {
                            requestModel.token = responseUserLogon.token;
                        }
                        else
                        {
                            logger.Log(LogLevels.Error, "Error while logging in.");
                            MessageBox.Show(this, "Error while logging in.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            metroButton2.Enabled = true;
                            return;
                        }
                    }

                    DataTable dt = parser.ParseCSV(txtCsvFilePath.Text);
                    int index = 1;
                    int count = dt.Rows.Count;
                    metroLabel4.Visible = true;
                  
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            requestModel.businessObjectId = row["BOID"].ToString().Trim('"');
                            var taskResponse = apiCalls.getDeclarationAttachments(requestModel);
                            if (taskResponse == null)
                            {
                                logger.Log(LogLevels.Info, "Skipping " + requestModel.businessObjectId + " document. No response.");
                                continue;
                            }
                            if (!taskResponse.IsCompleted)
                                Thread.Sleep(100);
                            AttachmentResponse attachmentResponse = taskResponse.Result;

                            logger.Log(LogLevels.Debug, JsonSerializer.Serialize(attachmentResponse));
                            if (attachmentResponse.hasErrors)
                            {
                                logger.Log(LogLevels.Error, "Error while getting document. BOID:" + requestModel.businessObjectId);
                            }
                            else
                            {
                                List<string> toAddInName = new List<string>();
                                for (int i = 7; i < dt.Columns.Count; i++)
                                {
                                    toAddInName.Add(row[i] != null ? row[i].ToString() : "");
                                }
                                SaveAttachments(saveDownloadsFolderPath, row, attachmentResponse, toAddInName);
                            }
                           
                        }
                        catch (Exception ex)
                        {
                            metroLabel4.Visible = false;
                            logger.Log(LogLevels.Error, ex.Message);
                            logger.Log(LogLevels.Error, ex.StackTrace);
                        }
                        logger.Log(LogLevels.Info, String.Format("Processed {0} out of {1}.", index, count));
                        metroLabel4.Text = String.Format("Processed {0} out of {1}.", index, count);
                        index++;
                    }
                    MessageBox.Show("Processing finished");
                    //metroLabel4.Visible = false;
                    metroButton2.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(this, ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                metroButton2.Enabled = true;
            }

            

        }

        private void SaveAttachments(string saveDownloadsFolderPath, DataRow row, AttachmentResponse attachmentResponse, List<string> toAddInName)
        {
            DateTime objDateTime;
            string date;
            string importerName = row["Importer"].ToString().Trim('"');
            string exportrName = row["Exporter"].ToString().Trim('"');
            string importExportFolderName = "";
            if (DateTime.TryParse(row["Declaration date"].ToString().Trim('"'), out objDateTime))
            {
                date = objDateTime.ToString("yyyyMMdd");
            }
            else
                date = DateTime.Now.ToString("yyyyMMdd");
            foreach (Attachment attachment in attachmentResponse.attachments)
            {
                switch (ddlCustomsDeclaration.SelectedIndex)
                {
                    case 1:
                    case 3: //import , transit
                        importExportFolderName = importerName;
                        break;
                    case 2: //Export
                        importExportFolderName = exportrName;
                        break;
                    default:
                        importExportFolderName = "ImporterExporterNotAvailable";
                        break;
                }
                string finalFolder = saveDownloadsFolderPath + "\\" + date + "\\" + importExportFolderName;
                CreateDirectory(finalFolder);

                byte[] data = Convert.FromBase64String(attachment.data);
                string decodedString = Encoding.UTF8.GetString(data);
                string extension = "";
                string finalFilePath = "";
                if (decodedString.Contains("PDF"))
                    extension = ".pdf";

                finalFilePath = finalFolder + "\\"+ ddlCustomsDeclaration.SelectedItem.ToString() + "-" 
                    + ddlDocumentType.SelectedItem.ToString() + "-"
                    + GetSubstring(importerName, 25) + "-"
                    + GetSubstring(exportrName, 25) + "-"
                    + row["Commercial reference"].ToString().Trim('"') + "-" 
                    + row["MRN"].ToString().Trim('"');
                foreach (string item in toAddInName)
                {
                    finalFilePath += "-" + item.Trim('"');
                }
                finalFilePath += extension;
                FileStream stream =
                               new FileStream(finalFilePath, FileMode.Create);
                using (BinaryWriter binaryWriter =
                new BinaryWriter(stream))
                {
                    binaryWriter.Write(data, 0, data.Length);
                }


                stream.Dispose();
                stream.Close();

            }
        }

        private string GetSubstring(string importExportFolderName, int v)
        {
            if (importExportFolderName.Length > 25)
                return importExportFolderName.Substring(0, 25);
            else
                return importExportFolderName;
        }

        private void ReadIniFile(IniParser.Model.IniData iniData, RequestModel requestModel)
        {
            requestModel.url = iniData["Settings"]["AEBURL"];
            requestModel.clientIdentCode = iniData["Settings"]["ClientCode"];
            requestModel.userName = iniData["Settings"]["Username"];
            requestModel.password = iniData["Settings"]["Password"];
            requestModel.resultLanguageIsoCodes = iniData["Settings"]["ResultLanguage"];
            requestModel.clientName = iniData["Settings"]["ClientCode"];
            requestModel.isExternalLogon = "true";
            requestModel.customsProcess = ddlCustomsDeclaration.SelectedItem.ToString();
            requestModel.attachmentCodes = ddlDocumentType.SelectedItem.ToString();

        }
        private static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }

}
