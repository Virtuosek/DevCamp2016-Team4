using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.Model
{
    public class Activity : ObservableObject
    {
        public int ID { get; set; }
        public int FkUser { get; set; }
        public User Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<User> Members { get; set; }

        public Activity()
        {
            Members = new List<User>();
            Owner = new User();
        }
    }
}
