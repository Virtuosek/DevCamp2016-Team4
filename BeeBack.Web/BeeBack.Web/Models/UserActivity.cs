using System;
using BeeBack.Data.Models;

namespace BeeBack.Web.Models
{
    public class UserActivity
    {
        public Guid ID { get; set; }

        public string UserID{ get; set; }
        public ApplicationUser User { get; set; }

        public Guid ActivityID { get; set; }
        public Activity Activity { get; set; }
    }
}
