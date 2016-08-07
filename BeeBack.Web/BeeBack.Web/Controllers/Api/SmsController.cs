using System.Linq;
using System.Web.Http;
using BeeBack.Web.Models;
using BeeBack.Web.Models.Twilio;

namespace BeeBack.Web.Controllers.Api
{
    public class SmsController : ApiController
    {
        [HttpPost]
        [Route("api/sms/reply")]
        public bool PostReply(TwiML message)
        {
            var parts = message.Body.ToLower().Split(' ');
            if (parts[0] == "oui")
            {
                var shortcode = parts[1];

                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var activity = context.Activities.FirstOrDefault(a => a.ShortCode == shortcode);
                    if (activity != null)
                    {
                        var user = context.Users.FirstOrDefault(u => u.PhoneNumber == message.From);
                        if (user != null)
                        {
                            activity.Driver = user;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        [HttpPost]
        [Route("api/sms/callback")]
        public void PostCallback()
        {

        }
    }
}
