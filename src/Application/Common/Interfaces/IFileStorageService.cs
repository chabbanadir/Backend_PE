namespace Backend.Application.Common.Interfaces
{
    public interface IFileStorageService
    {
        Task SaveFile(byte[] fileBytes, string fileName);
        string GetFilePath(string fileName);
        // Other file-related methods as needed
    }
}
