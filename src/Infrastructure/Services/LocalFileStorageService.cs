using System.IO;
using System.Threading.Tasks;
using Backend.Application.Common.Interfaces;

namespace Backend.Infrastructure.Services
{
    public class LocalFileStorageService : IFileStorageService
    {
        private readonly string _storageDirectory;

        public LocalFileStorageService(string storageDirectory)
        {
            _storageDirectory = storageDirectory;
        }

        public async Task SaveFile(byte[] fileBytes, string fileName)
        {
            var filePath = Path.Combine(_storageDirectory, fileName);
            await File.WriteAllBytesAsync(filePath, fileBytes);
        }
        public string GetFilePath(string fileName)
        {
            // Combine the file name with the file storage directory to get the full file path
            string filePath = Path.Combine(_storageDirectory, fileName);

            return filePath;
        }
        // Implement other file-related methods as needed
    }
}
