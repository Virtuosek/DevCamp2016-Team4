using BeeBack.Web.Models;

namespace BeeBack.Web.Interfaces
{
    public interface IUserService
    {
        ApplicationUser GetUserById(string id);
    }
}