using BeeBack.Data.Models;
using BeeBack.Web.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace BeeBack.Web.Controllers.Api
{
    public class ActivitiesController : BaseApiController
    {
        public async Task<List<Activity>> GetActivities()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Activities.ToListAsync();
            }
        }
    }
}
