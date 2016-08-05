using BeeBack.Model;
using BeeBack.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.Services
{
    public class DataService : IDataService
    {
        private static string _username;
        private static string _password;

        public static readonly string UrlBase = "http://beeback.azurewebsites.net/";
        public static readonly string UrlActivities = "api/activities";
        public static readonly string UrlSubscriptions = "api/subscriptions";
        public static readonly string UrlLogin = "api/login";

        public void Initialize(string username, string password)
        {
            _username = username;
            _password = password;

            if (string.IsNullOrWhiteSpace(_password))
                throw new UnauthorizedAccessException("Password is empty.");

            if (string.IsNullOrWhiteSpace(_username))
                throw new UnauthorizedAccessException("Username is empty.");
        }

        public async Task<bool> CheckCredentials()
        {
            using (var request = InitRequest())
            {
                var content = await request.GetStringAsync(UrlBase + UrlLogin);
                return JsonConvert.DeserializeObject<bool>(content);
            }
        }

        /// <summary>
        /// Get the list of activities to which the current user is subscribed
        /// </summary>
        /// <returns></returns>
        public async Task<List<Activity>> GetSubscribedActivities()
        {
            using (var request = InitRequest())
            {
                var content = await request.GetStringAsync(UrlBase + UrlSubscriptions);
                return JsonConvert.DeserializeObject<List<Activity>>(content);
            }
        }

        /// <summary>
        /// Get the list of activities created by the user.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Activity>> GetUserActivities()
        {
            using (var request = InitRequest())
            {
                var content = await request.GetStringAsync(UrlBase + UrlActivities);
                return JsonConvert.DeserializeObject<List<Activity>>(content);
            }
        }

        /// <summary>
        /// Get the list of all public activities 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Activity>> GetAllPublicActivities()
        {
            using (var request = InitRequest())
            {
                var content = await request.GetStringAsync(UrlBase + UrlActivities);
                return JsonConvert.DeserializeObject<List<Activity>>(content);
            }
        }

        public Task<DataItem> GetData()
        {
            // Use this to connect to the actual data service

            // Simulate by returning a DataItem
            var item = new DataItem("Welcome to MVVM Light");
            return Task.FromResult(item);
        }

        private HttpClient InitRequest()
        {
            HttpClient client = new HttpClient();

            if (string.IsNullOrWhiteSpace(_password) || string.IsNullOrWhiteSpace(_username))
            {
                throw new UnauthorizedAccessException("Credentials are missing. Initialize the service first.");
            }

            var byteArray = Encoding.ASCII.GetBytes($"{_username}:{_password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            return client;
        }
    }
}