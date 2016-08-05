using System;
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
    }
}