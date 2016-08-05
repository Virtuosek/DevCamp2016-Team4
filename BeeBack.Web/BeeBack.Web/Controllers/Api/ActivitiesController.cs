using BeeBack.Data.Models;
using BeeBack.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BeeBack.Web.Controllers.Api
{
    public class ActivitiesController : ApiController
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
