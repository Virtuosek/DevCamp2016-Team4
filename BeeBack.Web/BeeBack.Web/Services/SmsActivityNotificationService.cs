using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeeBack.Web.Interfaces;
using BeeBack.Web.Models;

namespace BeeBack.Web.Services
{
    public class SmsActivityNotificationService : IActivityNotificationService
    {
        public void NotifySubscribedUsers(Activity activity)
        {
            var twilio = new Twilio.TwilioRestClient("SK801c217a29edcb346742b0e3f64ff34b", "vQxk9lem1tQAkZNgmZwNAVmpqYxqxl28");
            var phoneNumber = twilio.GetIncomingPhoneNumber("PN807993f491b0c08be90ed6df0481b49d");

            foreach (var userActivity in activity.UserActivities)
            {
                var phone = userActivity.User.PhoneNumber;
                var message = twilio.SendMessage(phoneNumber.PhoneNumber, phone,
                    $"L'activité {activity.Title} aura bientôt lieu: {activity.Date}. Répondez OUI si vous acceptez d'être chauffeur.");
            }
        }
    }
}
