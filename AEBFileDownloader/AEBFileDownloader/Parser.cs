using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace AEBFileDownloader
{
    
    internal class Parser
    {
        public IniData Parse()
        {
            var iniParser = new FileIniDataParser();
            return iniParser.ReadFile("Configuration.ini");
        }

        public DataTable ParseCSV(string filePath)
        {
            string[] lines  = File.ReadAllLines(filePath);
            DataTable dt = new DataTable();
            bool headerAdded = false;
          
            foreach (string line in lines)
            {
                if (!headerAdded)
                {
                    string[] headers = lines[0].Split(';');
                    foreach (string header in headers)
                        dt.Columns.Add(header);
                    headerAdded = true;
                }
                else
                {
                    dt.Rows.Add(line.Split(';'));
                }
            }
            return dt;
        }
    }

}
