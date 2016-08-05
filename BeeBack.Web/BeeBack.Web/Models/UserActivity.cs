using BeeBack.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.Data.Models
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
