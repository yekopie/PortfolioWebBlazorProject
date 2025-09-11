

namespace PortfolioApp.MinimalCore.FileStorage
{
    public class FileStorageService(string rootPath) : IFileStorageService
    {
        public void Delete(string fileUrl)
        {
            var uri = new Uri(fileUrl);
            var relativePath = Uri.UnescapeDataString(uri.AbsolutePath.TrimStart('/'));

            var filePath = Path.Combine(rootPath, relativePath);

            var fullRootPath = Path.GetFullPath(rootPath);
            var fullFilePath = Path.GetFullPath(filePath);

            if (!fullFilePath.StartsWith(fullRootPath, StringComparison.OrdinalIgnoreCase))
                throw new UnauthorizedAccessException("Yetkisiz dizin erişimi.");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Silinecek dosya bulunamıyor.", filePath);

            File.Delete(filePath);
        }

        public async Task<string> UploadAsync(
            Stream file,
            string relativePath,
            string fileName,
            CancellationToken cancellationToken = default)
        {
            file.Position = 0;

            var fullDirectoryPath = Path.Combine(rootPath, relativePath);
            Directory.CreateDirectory(fullDirectoryPath);

            var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
            var fullFilePath = Path.Combine(fullDirectoryPath, uniqueFileName);

            await using var fileStream = new FileStream(fullFilePath, FileMode.Create, FileAccess.Write);
            await file.CopyToAsync(fileStream, cancellationToken);

            var normalizedPath = relativePath.Replace("\\", "/").TrimStart('/');
            return $"/{normalizedPath}/{uniqueFileName}";
        }
    }

}
