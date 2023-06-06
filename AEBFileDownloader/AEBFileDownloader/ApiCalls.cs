using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Logging_Framework;

namespace AEBFileDownloader
{
    internal class ApiCalls
    {
        static RestClient client = null;
        Logging_Framework.Logger log;
        
        public ApiCalls(Logging_Framework.Logger logger)
        {
            log = logger;
            
            RestClientOptions options = new RestClientOptions()
            {
                Timeout = -1,
                Proxy = new WebProxy() { BypassProxyOnLocal = true }
            };
            client = new RestClient(options);           
        }

        public Task<UserLogon> LogonUser(RequestModel requestModel)
        {
            try
            {
                var body = @"{ ""userName"": """+ requestModel.userName + @""", ""password"": """+ requestModel.password 
                    + @""", ""clientName"": """+ requestModel.clientName + @""", ""localeName"": """ + requestModel.localeName 
                    + @""", ""isExternalLogon"": """+ requestModel.isExternalLogon + @""" }";
                
                string url = requestModel.url + "/logon/user";
                var request = new RestRequest(url).AddStringBody(body, "application/json");
                
                request.Method = Method.Post;
                log.Log(LogLevels.Debug, body);
                return client.PostAsync<UserLogon>(request);

            }
            catch (HttpRequestException ex)
            {
                //log
              
                return null;
            }


        }

        

        public Task<AttachmentResponse> getDeclarationAttachments(RequestModel requestModel)
        {
            try
            {
                var body = @"{""clientSystemId"": ""API"",""clientIdentCode"": """ + requestModel.clientIdentCode
                    + @""", ""userName"": """ + requestModel.userName
                    + @""",""resultLanguageIsoCodes"": [""" + requestModel.resultLanguageIsoCodes
                    + @"""],""customsProcess"": {""customsProcess"": """ + requestModel.customsProcess
                    + @"""},""businessObjectId"":""" + requestModel.businessObjectId
                    + @""",""attachmentCodes"": [""" + requestModel.attachmentCodes
                    + @"""]}";
                log.Log(LogLevels.Debug, body);
                string url = requestModel.url + "/InternationalCustomsBFBean/getDeclarationAttachments";
                var request = new RestRequest(url).AddStringBody(body, "application/json");
                request.Method = Method.Post;
                request.AddHeader("X-XNSG_WEB_TOKEN",requestModel.token);
                return client.PostAsync<AttachmentResponse>(request);

            }
            catch(Exception ex)
            {
                log.Log(LogLevels.Error, ex.ToString());
                return null;
            }
            

        }
    }
}
