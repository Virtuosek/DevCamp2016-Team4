using BeeBack.Web.Models;

namespace BeeBack.Web.Interfaces
{
    public interface IActivityNotificationService
    {
        void NotifySubscribedUsers(Activity activity);
        void SendDriverConfirmation(Activity activity);
    }
}
