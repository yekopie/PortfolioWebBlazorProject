

namespace PortfolioApp.MinimalCore.FileStorage
{
    public class FileUploadResult
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
    }

}
