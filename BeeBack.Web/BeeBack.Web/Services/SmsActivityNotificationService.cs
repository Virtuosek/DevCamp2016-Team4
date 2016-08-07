using BeeBack.Web.Interfaces;
using BeeBack.Web.Models;

namespace BeeBack.Web.Services
{
    public class SmsActivityNotificationService : IActivityNotificationService
    {
        public void NotifySubscribedUsers(Activity activity)
        {
            var twilio = new Twilio.TwilioRestClient("ACba61716bbf4e431290e8d11868616813", "a0bea4676879689faba0c055e116c263");
            //var phoneNumber = twilio.GetIncomingPhoneNumber("PN807993f491b0c08be90ed6df0481b49d");
            var phoneNumber = twilio.GetIncomingPhoneNumber("PN0d57152a395c027dcb15a01c1263eb10"); 

            foreach (var userActivity in activity.UserActivities)
            {
                var phone = userActivity.User.PhoneNumber;
                var message = twilio.SendMessage(phoneNumber.PhoneNumber, phone,
                    $"L'activité {activity.Title} aura bientôt lieu: {activity.Date}. Répondez OUI {activity.ShortCode} si vous acceptez d'être chauffeur.");
            }
        }

        public void SendDriverConfirmation(Activity activity)
        {
            var twilio = new Twilio.TwilioRestClient("ACba61716bbf4e431290e8d11868616813", "a0bea4676879689faba0c055e116c263");
            //var phoneNumber = twilio.GetIncomingPhoneNumber("PN807993f491b0c08be90ed6df0481b49d");
            var phoneNumber = twilio.GetIncomingPhoneNumber("PN0d57152a395c027dcb15a01c1263eb10");

            var driverConfirmation = twilio.SendMessage(phoneNumber.PhoneNumber, activity.Driver.PhoneNumber,
                    $"Merci pilote ! Vous êtes prié de ne plus boire de bière 2h avant le départ.");

            foreach (var userActivity in activity.UserActivities)
            {
                var phone = userActivity.User.PhoneNumber;
                var message = twilio.SendMessage(phoneNumber.PhoneNumber, phone,
                    $"L'activité {activity.Title} a trouvé son pilote. On remercie {activity.Driver.Firstname} {activity.Driver.Lastname}.");
            }
        }
    }
}
