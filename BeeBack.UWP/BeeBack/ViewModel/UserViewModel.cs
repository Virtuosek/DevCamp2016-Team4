using BeeBack.Messages;
using BeeBack.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        private User _user;
        public UserViewModel()
        {
            Messenger.Default.Register<SetUserModelMessage>(this, OnSetUserMessageReceived);
        }

        private void OnSetUserMessageReceived(SetUserModelMessage message)
        {
            User = message.User;
            RaisePropertyChanged(() => User);
        }


        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged(() => User);
            }
        }




    }
}
