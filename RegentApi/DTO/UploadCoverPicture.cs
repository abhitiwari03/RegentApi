using System.ServiceModel.Channels;

namespace RegentApi.DTO
{
    public class UploadCoverPicture
    {
        public string Path { get; }
        public string Message { get; }
        public int UploadStatus { get; }

        public UploadCoverPicture(string path, string message, int uploadStatus)
        {
            Path = path;
            Message = message;
            UploadStatus = uploadStatus;
        }
    }
    
}
