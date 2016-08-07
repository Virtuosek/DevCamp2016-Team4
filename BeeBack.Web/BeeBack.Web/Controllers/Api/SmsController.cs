using System.Linq;
using System.Web.Http;
using BeeBack.Web.Models;
using BeeBack.Web.Models.Twilio;
using BeeBack.Web.Services;
using System.Data.Entity;
using System.Net.Http;
using System.Text;

namespace BeeBack.Web.Controllers.Api
{
    public class SmsController : ApiController
    {
        [HttpPost]
        [Route("api/sms/reply")]
        public HttpResponseMessage PostReply(TwiML message)
        {
            string responseText = "La requête n'est pas correcte !";

            var parts = message.Body.ToLower().Split(' ');
            if (parts[0] == "oui")
            {
                var shortcode = parts[1];

                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var activity = context
                        .Activities.Include(a => a.UserActivities)
                        .Include("UserActivities.User")
                        .FirstOrDefault(a => a.ShortCode == shortcode);

                    if (activity != null)
                    {
                        var user = context.Users.FirstOrDefault(u => u.PhoneNumber == message.From);
                        if (user != null)
                        {
                            activity.Driver = user;
                            context.SaveChanges();

                            var smsService = new SmsActivityNotificationService();
                            smsService.SendDriverConfirmation(activity);

                            responseText = "Merci !";
                        }
                    }
                }
            }

            HttpResponseMessage response = new HttpResponseMessage()
            {
                Content = new StringContent(
               responseText,
               Encoding.UTF8,
               "plain/text")
            };

            return response;
        }

        [HttpPost]
        [Route("api/sms/callback")]
        public void PostCallback()
        {

        }
    }
}
