using System.Threading.Tasks;
using Windows.Storage;

namespace BeeBack.Services.Interfaces
{
    public interface IStorageService
    {
        Task<byte[]> GetBytes(string path);
        Task<StorageFile> GetFile(StorageFolder storageFolder, string fileName);
        Task<StorageFile> GetFile(Folder folder, string fileName);
        Task<StorageFolder> GetFolder(Folder folder);
        Task<string> GetText(string path);
        Task<StorageFile> SaveBytes(StorageFolder folder, string fileName, byte[] contents);
        Task<StorageFile> SaveText(StorageFolder folder, string fileName, string contents);
    }
}