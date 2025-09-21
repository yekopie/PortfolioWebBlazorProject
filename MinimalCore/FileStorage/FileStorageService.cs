

namespace PortfolioApp.MinimalCore.FileStorage
{
    public class FileStorageService(string rootPath = "") : IFileStorageService
    {
        public void Delete(string fileUrl)
        {
            var filePath = Path.Combine(rootPath, Uri.UnescapeDataString(fileUrl.TrimStart('/')));

            var fullRootPath = Path.GetFullPath(rootPath);
            var fullFilePath = Path.GetFullPath(filePath);

            if (!fullFilePath.StartsWith(fullRootPath, StringComparison.OrdinalIgnoreCase))
                throw new UnauthorizedAccessException("Yetkisiz dizin erişimi.");

            if (File.Exists(fullFilePath))
                File.Delete(fullFilePath);
        }

        public async Task<FileUploadResult> UploadAsync(
            Stream file,
            string relativePath,
            string fileName,
            CancellationToken cancellationToken = default)
        {

            var extension = Path.GetExtension(fileName);
            var directoryPath = Path.Combine(rootPath, relativePath);
            Directory.CreateDirectory(directoryPath);

            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
            var fullFilePath = Path.Combine(directoryPath, uniqueFileName);

            await using var fileStream = new FileStream(fullFilePath, FileMode.Create, FileAccess.Write);
            await file.CopyToAsync(fileStream, cancellationToken);

            return new FileUploadResult
            {
                Path = $"{relativePath.Replace("\\", "/").TrimEnd('/')}/{uniqueFileName}",
                FileName = uniqueFileName,
                ContentType = extension, // MIME type burada extension değil! ileride değiştirebilirsin
                Size = fileStream.Length
            };
        }
    }

}
