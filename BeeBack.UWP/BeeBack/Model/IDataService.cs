using System.Threading.Tasks;

namespace BeeBack.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}