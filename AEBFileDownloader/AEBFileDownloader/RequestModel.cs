using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEBFileDownloader
{
    internal class RequestModel
    {
        public string localeName = "en";
        public string userName, password, clientName, isExternalLogon, clientSystemId, clientIdentCode, resultLanguageIsoCodes, 
            customsProcess, businessObjectId, attachmentCodes, url, token;
        public bool isAuthenticated = false;
        

    }
}
