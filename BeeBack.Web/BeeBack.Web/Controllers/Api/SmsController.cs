using System.Web.Http;
using BeeBack.Web.Models.Twilio;

namespace BeeBack.Web.Controllers.Api
{
    public class SmsController : ApiController
    {
        [HttpPost]
        [Route("api/sms/reply")]
        public void PostReply(TwiML message)
        {

        }

        [HttpPost]
        [Route("api/sms/callback")]
        public void PostCallback()
        {

        }
    }
}
