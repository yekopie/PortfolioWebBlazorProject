
namespace PortfolioApp.MinimalCore.FileStorage
{
    public interface IFileStorageService
    {
        Task<FileUploadResult> UploadAsync(Stream file, string relativePath, string fileName, CancellationToken cancellationToken = default);
        void Delete(string fileUrl);
    }
}
