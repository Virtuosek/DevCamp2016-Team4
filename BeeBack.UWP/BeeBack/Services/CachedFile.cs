using System;

using System.Threading.Tasks;
using Windows.Storage;
using System.Net.Http;
using Windows.Storage.FileProperties;
using System.Diagnostics;

namespace LeSoir.Common
{
    public class CachedFile
    {
        private static string GetFileName(string WebServiceAddress)
        {
            string rst = WebServiceAddress;
            rst = rst.Replace(":", "");
            rst = rst.Replace("/", "");
            rst = rst.Replace(",", "");
            rst = rst.Replace(".", "");
            rst = rst.Replace("?", "");
            rst = rst.Replace("=", "");
            rst = rst.Replace("&", "");
            rst = rst.Replace("#", "");
            rst = rst.Replace(">", "");
            rst = rst.Replace("<", "");
            rst = rst.Replace("http", "");
            rst = string.Format("{0}.json", rst);
            return rst;
        }
        private async static Task<DateTime> FileDate(string WebServiceAddress, bool UseRoaming = false)
        {
            DateTime rst;
            try
            {
                string filename = GetFileName(WebServiceAddress);
                StorageFolder roamingFolder;
                if (UseRoaming)
                {
                    roamingFolder = ApplicationData.Current.RoamingFolder;
                }
                else
                {
                    roamingFolder = ApplicationData.Current.LocalFolder;
                }
                StorageFile fichier = await roamingFolder.GetFileAsync(filename);
                BasicProperties properties = await fichier.GetBasicPropertiesAsync();

                rst = properties.DateModified.UtcDateTime;
            }
            catch
            {
                rst = new DateTime(2000, 1, 1);
            }
            return rst;
        }
        private async static Task<bool> MustLoad(string WebServiceAddress, TimeSpan CacheMaxAge, bool UseRoaming = false)
        {
            bool rst = true;
            try
            {
                DateTime datefichier = await FileDate(WebServiceAddress, UseRoaming);
                TimeSpan diff = DateTime.UtcNow.Subtract(datefichier);

                if (CacheMaxAge > diff)
                {
                    rst = false;
                }
            }
            catch
            { }
            return rst;
        }
        public static async Task<T> TryLoad<T>(string WebServiceAddress, TimeSpan CacheMaxAge, bool UseRoaming = false, bool ForceLoad = false, HttpClient cli = null)
        {
            T result = default(T);
            bool bLoad = true;

            try
            {
                if (!ForceLoad)
                    bLoad = await MustLoad(WebServiceAddress, CacheMaxAge, UseRoaming);

                if (bLoad)
                {
                    if (cli == null)
                        cli = new HttpClient();

                    string str = await cli.GetStringAsync(WebServiceAddress);
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
                    await SaveClass<T>(GetFileName(WebServiceAddress), result);
                }
                else
                    result = await LoadClass<T>(GetFileName(WebServiceAddress));

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return result;
            }

        }
        public static async Task SaveClass<T>(string filename, T anobject, bool UseRoaming = false)
        {
            StorageFolder roamingFolder;
            if (UseRoaming)
            {
                roamingFolder = ApplicationData.Current.RoamingFolder;
            }
            else
            {
                roamingFolder = ApplicationData.Current.LocalFolder;
            }
            StorageFile sampleFile =
                await roamingFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            string donnees = Newtonsoft.Json.JsonConvert.SerializeObject(anobject);
            await FileIO.WriteTextAsync(sampleFile, donnees);
        }
        public static async Task<T> LoadClass<T>(string filename, bool UseRoaming = false)
        {
            StorageFolder roamingFolder;
            if (UseRoaming)
            {
                roamingFolder = ApplicationData.Current.RoamingFolder;
            }
            else
            {
                roamingFolder = ApplicationData.Current.LocalFolder;
            }
            try
            {
                StorageFile sampleFile = await roamingFolder.GetFileAsync(filename);
                String machaine = await FileIO.ReadTextAsync(sampleFile);
                return (T)Newtonsoft.Json.JsonConvert.DeserializeObject<T>(machaine);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
