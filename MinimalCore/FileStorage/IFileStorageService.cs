
namespace PortfolioApp.MinimalCore.FileStorage
{
    public interface IFileStorageService
    {
        Task<string> UploadAsync(Stream file, string relativePath, string fileName, CancellationToken cancellationToken = default);
        void Delete(string fileUrl);
    }
}
