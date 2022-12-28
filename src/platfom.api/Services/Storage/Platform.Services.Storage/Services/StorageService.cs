using Platform.Services.Storage.Services.Abstractions;


namespace Platform.Services.Storage.Services;

public class StorageService : IStorageService
{
    readonly IStorageService _storage;

    public StorageService(IStorageService storage) { _storage = storage; }

    public string StorageName { get => _storage.GetType().Name; }

    public async Task DeleteAsync(string path, string fileName) => await _storage.DeleteAsync(path, fileName);

    public List<string> GetAllFiles(string path) => _storage.GetAllFiles(path);

    public bool HasFile(string path, string fileName) => _storage.HasFile(path, fileName);

    public Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files) => _storage.UploadAsync(path, files);
}
