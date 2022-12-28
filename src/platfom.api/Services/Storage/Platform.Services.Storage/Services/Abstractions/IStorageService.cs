namespace Platform.Services.Storage.Services.Abstractions;

public interface IStorageService
{
    List<string> GetAllFiles(string path);

    bool HasFile(string path, string fileName);

    Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files);

    Task DeleteAsync(string path, string fileName);
}
