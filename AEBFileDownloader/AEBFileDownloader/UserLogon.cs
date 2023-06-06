using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEBFileDownloader
{
    internal class UserLogon
    {

        public string token { get; set; }
        public string userName { get; set; }
        public string client { get; set; }
        public List<string> roles { get; set; }
        public string error { get; set; }
    }
}
