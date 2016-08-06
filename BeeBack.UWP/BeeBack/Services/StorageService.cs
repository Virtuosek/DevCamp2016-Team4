using BeeBack.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace BeeBack.Services
{
    public class StorageService : IStorageService
    {
        public async Task<StorageFolder> GetFolder(Folder folder)
        {
            var result = ApplicationData.Current.LocalFolder;

            switch (folder)
            {
                case Folder.Temporary:
                    result = ApplicationData.Current.TemporaryFolder;
                    break;
                case Folder.Settings:
                    result = await result.CreateFolderAsync("Settings", CreationCollisionOption.OpenIfExists);
                    break;
            }

            return result;
        }

        public async Task<StorageFile> GetFile(Folder folder, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return null;
            }

            var storageFolder = await this.GetFolder(folder);

            var file = await this.GetFile(storageFolder, fileName);

            return file;
        }

        public async Task<StorageFile> GetFile(StorageFolder storageFolder, string fileName)
        {
            var files = await storageFolder.GetFilesAsync();
            var file = files.FirstOrDefault(x => x.Name == fileName);
            return file;
        }

        public async Task<StorageFile> SaveBytes(StorageFolder folder, string fileName, byte[] contents)
        {
            var file = await CreateStorageFile(folder, fileName);

            if (file != null)
            {
                await FileIO.WriteBytesAsync(file, contents);
            }

            return file;
        }

        public async Task<StorageFile> SaveText(StorageFolder folder, string fileName, string contents)
        {
            var file = await CreateStorageFile(folder, fileName);

            if (file != null)
            {
                await FileIO.WriteTextAsync(file, contents);
            }

            return file;
        }

        public async Task<string> GetText(string path)
        {
            var file = await StorageFile.GetFileFromPathAsync(path);
            var contents = await FileIO.ReadTextAsync(file);

            return contents;
        }

        public async Task<byte[]> GetBytes(string path)
        {
            var file = await StorageFile.GetFileFromPathAsync(path);

            using (IRandomAccessStream stream = await file.OpenReadAsync())
            {
                using (var reader = new DataReader(stream.GetInputStreamAt(0)))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    var contents = new byte[stream.Size];
                    reader.ReadBytes(contents);
                    return contents;
                }
            }
        }

        private static async Task<StorageFile> CreateStorageFile(IStorageFolder folder, string fileName)
        {
            StorageFile file = null;

            if (folder == null)
                return null;

            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            return file;
        }
    }

    public enum Folder
    {
        Temporary,
        Local,
        Settings
    }
}
