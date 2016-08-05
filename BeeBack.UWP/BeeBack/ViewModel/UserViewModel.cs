using BeeBack.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        public UserViewModel()
        {
            _user = new User();
            _user.EMailAddress = "tot@totofds.be";
            _user.Name = "Smith";
            _user.FirstName = "John";
            _user.MobilePhone = "+32475123456";
            Activity a;
            for (int i = 0; i<10; i++)
            {
                a = new Activity();
                a.Title = "jfkldsjfmlkjdsfdsqfjsl lkj mls fs lkj ldskj fmlq";
                a.Description = "kjmlkf jfdslk jfmlkds fjlk jflksjflks jfmlks jmlks jfjs fljzfljsid flkjzljez lkjhkjhf kjsh flksf mlkjs flksj flkdsj fmlksjd fmlkjds fmlkez";
                _user.Activities.Add(a);
            }

        }
        private User _user;

        public User User
        {
            get { return _user; }
            set { _user = value; RaisePropertyChanged("User"); }
        }

    }
}
