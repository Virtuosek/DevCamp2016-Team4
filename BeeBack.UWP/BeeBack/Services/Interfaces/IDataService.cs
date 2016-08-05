using BeeBack.Model;
using System.Threading.Tasks;

namespace BeeBack.Services.Interfaces
{
    public interface IDataService
    {
        void Initialize(string username, string password);
        Task<DataItem> GetData();
        Task<bool> CheckCredentials();
    }
}