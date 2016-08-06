using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeeBack.Web.Models;

namespace BeeBack.Data.Models
{
    public class Activity
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<UserActivity> UserActivities { get; set; }
    }
}
