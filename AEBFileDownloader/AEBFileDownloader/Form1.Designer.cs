namespace AEBFileDownloader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.ddlDocumentType = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.ddlCustomsDeclaration = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.txtCsvFilePath = new System.Windows.Forms.TextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabPage1);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Padding = new System.Drawing.Point(6, 8);
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(754, 357);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.metroLabel4);
            this.tabPage1.Controls.Add(this.metroButton2);
            this.tabPage1.Controls.Add(this.ddlDocumentType);
            this.tabPage1.Controls.Add(this.metroLabel3);
            this.tabPage1.Controls.Add(this.ddlCustomsDeclaration);
            this.tabPage1.Controls.Add(this.metroLabel2);
            this.tabPage1.Controls.Add(this.metroButton1);
            this.tabPage1.Controls.Add(this.txtCsvFilePath);
            this.tabPage1.Controls.Add(this.metroLabel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(746, 315);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Download Files";
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(488, 232);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(186, 46);
            this.metroButton2.TabIndex = 7;
            this.metroButton2.Text = "Download Files";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // ddlDocumentType
            // 
            this.ddlDocumentType.FormattingEnabled = true;
            this.ddlDocumentType.ItemHeight = 24;
            this.ddlDocumentType.Location = new System.Drawing.Point(200, 122);
            this.ddlDocumentType.Name = "ddlDocumentType";
            this.ddlDocumentType.Size = new System.Drawing.Size(310, 30);
            this.ddlDocumentType.TabIndex = 6;
            this.ddlDocumentType.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(31, 122);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(108, 20);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Document Type";
            // 
            // ddlCustomsDeclaration
            // 
            this.ddlCustomsDeclaration.FormattingEnabled = true;
            this.ddlCustomsDeclaration.ItemHeight = 24;
            this.ddlCustomsDeclaration.Location = new System.Drawing.Point(200, 86);
            this.ddlCustomsDeclaration.Name = "ddlCustomsDeclaration";
            this.ddlCustomsDeclaration.Size = new System.Drawing.Size(310, 30);
            this.ddlCustomsDeclaration.TabIndex = 4;
            this.ddlCustomsDeclaration.UseSelectable = true;
            this.ddlCustomsDeclaration.SelectedIndexChanged += new System.EventHandler(this.ddlCustomsDeclaration_SelectedIndexChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(31, 86);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(136, 20);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Customs Declaration";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(529, 51);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(33, 29);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = ". . .";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // txtCsvFilePath
            // 
            this.txtCsvFilePath.Location = new System.Drawing.Point(200, 51);
            this.txtCsvFilePath.Name = "txtCsvFilePath";
            this.txtCsvFilePath.Size = new System.Drawing.Size(310, 27);
            this.txtCsvFilePath.TabIndex = 1;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(31, 51);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(56, 20);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "CSV file";
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "openFileDialog1";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(31, 15);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(87, 20);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "metroLabel4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroTabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Cus Doc Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.TextBox txtCsvFilePath;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox ddlCustomsDeclaration;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox ddlDocumentType;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}
