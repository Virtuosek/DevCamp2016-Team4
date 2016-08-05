using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.Data.Models
{
    public class Activity
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
