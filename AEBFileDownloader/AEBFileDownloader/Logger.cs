using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEBFileDownloader
{
    internal static class Logger
    {
        public static Logging_Framework.Logger GetLogger(string logsPath, string v)
        {
            switch (v.ToLower())
            {
                case "debug":
                    return Logging_Framework.Logger.GetLogger(logsPath, "CusDoc_Downloader", Logging_Framework.LogLevels.Debug);
                    break;
                case "info":
                    return Logging_Framework.Logger.GetLogger(logsPath, "CusDoc_Downloader", Logging_Framework.LogLevels.Info);
                    break;
                case "error":
                    return Logging_Framework.Logger.GetLogger(logsPath, "CusDoc_Downloader", Logging_Framework.LogLevels.Error);
                default:
                    return Logging_Framework.Logger.GetLogger(logsPath, "CusDoc_Downloader", Logging_Framework.LogLevels.Info);
                    break;
            }

        }
    }
}
