using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

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
