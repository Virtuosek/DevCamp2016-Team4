using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeeBack.Web.Models
{
    public class Activity
    {
        public Activity()
        {
            Location = new Location();
            Date = DateTime.Now;
        }

        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public DateTime Date { get; set; }

        public Location Location { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<UserActivity> UserActivities { get; set; }
    }
}
