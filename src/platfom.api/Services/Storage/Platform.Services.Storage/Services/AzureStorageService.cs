using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using Platform.Services.Storage.Helpers;
using Platform.Services.Storage.Services.Abstractions;


namespace Platform.Services.Storage.Services;

public class AzureStorageService : StorageHelper, IAzureStorageService
{
    readonly BlobServiceClient _blobServiceClient;

    BlobContainerClient _blobContainerClient;


    public AzureStorageService(IConfiguration configuration)
    {
        _blobServiceClient = new(configuration["Storages:Azure:ConnectionString"]);
    }


    public List<string> GetAllFiles(string path)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);

        return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
    }

    public bool HasFile(string path, string fileName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);

        return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
    }

    public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);

        await _blobContainerClient.CreateIfNotExistsAsync();
        await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

        List<(string fileName, string path)> datas = new();

        foreach (IFormFile file in files)
        {
            string fileNewName = await FileRenameAsync(path, file.Name, HasFile);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
            await blobClient.UploadAsync(file.OpenReadStream());
            datas.Add((fileNewName, $"{path}/{fileNewName}"));
        }
        return datas;
    }

    public async Task DeleteAsync(string path, string fileName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
        BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);

        await blobClient.DeleteAsync();
    }
}