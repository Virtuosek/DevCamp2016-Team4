using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BeeBack.Web.Interfaces;
using BeeBack.Web.Models;

namespace BeeBack.Web.Services
{
    public class EmailActivityNotificationService : IActivityNotificationService
    {
        public void NotifySubscribedUsers(Activity activity)
        {
            SmtpClient client = new SmtpClient();
            var message = new MailMessage();
            message.From = new MailAddress("contact@beeback.com");
            message.To.Add(new MailAddress("no-reply@beeback.com"));

            foreach (var userActivity in activity.UserActivities)
            {
                var email = userActivity.User.Email;

                message.CC.Add(new MailAddress(email));
            }

            client.SendMailAsync(message);
        }

        public void SendDriverConfirmation(Activity activity)
        {
            
        }
    }
}
