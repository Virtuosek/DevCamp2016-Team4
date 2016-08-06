using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.Web.Models.Twilio
{
    public class TwiML
    {
        public string MessageSid { get; set; }
        public string AccountSid { get; set; }
        public string MessagingServiceSid { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public string NumMedia { get; set; }
    }
}
