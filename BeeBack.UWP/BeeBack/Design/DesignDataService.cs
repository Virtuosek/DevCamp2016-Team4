using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeeBack.Model;
using BeeBack.Services.Interfaces;

namespace BeeBack.Design
{
    public class DesignDataService : IDataService
    {
        public Task<DataItem> GetData()
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            return Task.FromResult(item);
        }

        public Task<bool> CheckCredentials()
        {
            throw new NotImplementedException();
        }


        public void Initialize(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<List<Activity>> GetUserActivities()
        {
            throw new NotImplementedException();
        }

        public Task<List<Activity>> GetSubscribedActivities()
        {
            throw new NotImplementedException();
        }

        public Task<List<Activity>> GetAllPublicActivities()
        {
            return Task.Run(() =>
            {
                List<Activity> activities = new List<Activity>();
                //    Activity a;
                //    User u;
                //    for (int i = 0; i < 50; i++)
                //    {
                //        a = new Activity();
                //        a.Description = " ksjf mlks jflksfs kjlkds jfmlks jflkds jflkds jflkds jflksd jfl kjld mj dmlkq jmlk jflkjf dsml lkj fmlksj mlkds lksj flkds jflkjs lkfj dsjf lk";
                //        a.Title = $"{i} Conduire les enfants à l'école tous les mardis matin";
                //        for (int j = 0; j < 10; j++)
                //        {
                //            u = new User();
                //            u.EMailAddress = "tot@totofds.be";
                //            u.Name = $"{j}Smith";
                //            u.FirstName = "John";
                //            u.MobilePhone = "+32475123456";
                //            if (j == 0)
                //            {
                //                a.Owner = u;
                //            }
                //            u.Activities.Add(a);
                //            a.Members.Add(u);
                //        }
                //        activities.Add(a);
                //    }

                return activities;
            });

        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string UserID)
        {
            throw new NotImplementedException();
        }
    }
}