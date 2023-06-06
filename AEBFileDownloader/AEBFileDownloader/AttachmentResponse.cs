using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEBFileDownloader
{
    internal class AttachmentResponse
    {
        public bool hasErrors { get; set; }
        public bool hasOnlyRetryableErrors { get; set; }
        public bool hasWarnings { get; set; }
        public List<Message> messages { get; set; }
        public List<Attachment> attachments { get; set; }
    }
    public class MessageText
    {
        public string languageISOCode { get; set; }
        public string text { get; set; }
    }

    public class Message
    {
        public string messageType { get; set; }
        public string messageIdentCode { get; set; }
        public List<MessageText> messageTexts { get; set; }
        public int indentationLevel { get; set; }
    }


    public class Attachment
    {
        public string attachmentCode { get; set; }
        public string data { get; set; }
        public string statusCode { get; set; }
        public string description { get; set; }
    }
}
