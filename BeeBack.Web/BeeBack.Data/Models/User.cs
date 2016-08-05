using System;
using System.Collections;
using System.Collections.Generic;

namespace BeeBack.Data.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
