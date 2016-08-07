using BeeBack.Web.Interfaces;
using BeeBack.Web.Models;

namespace BeeBack.Web.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public ApplicationUser GetUserById(string id)
        {
            return _db.Users.Find(id);
        }
    }
}
