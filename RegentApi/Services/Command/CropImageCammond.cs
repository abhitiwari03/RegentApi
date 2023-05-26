using AutoMapper;
using MediatR;
using RegentApi.Helpers;
using RegentApi.Models;
using System.Net;

namespace RegentApi.Services.Command
{
    public class CropImageCammond : IRequest<string>
    {
        public string ImagePath { get; set; }
        public int? CropPointX { get; set; }
        public int? CropPointY { get; set; }
        public int? ImageCropWidth { get; set; }
        public int? ImageCropHeight { get; set; }
    }
    public class uploadcroppicturehandler : IRequestHandler<CropImageCammond, string>
    {
        private readonly RegentDB_NewContext m_context;
        private readonly IMapper m_mapper;
        private readonly IMediator m_mediator;
        public uploadcroppicturehandler(RegentDB_NewContext context, IMapper mapper, IMediator mediator)
        {

            m_context = context;
            m_mapper = mapper;
            m_mediator = mediator;
        }

        public async Task<string> Handle(CropImageCammond command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.ImagePath) || !command.CropPointX.HasValue || !command.CropPointY.HasValue || !command.ImageCropWidth.HasValue || !command.ImageCropHeight.HasValue)
            {
                throw new ArgumentException("Invalid parameters for image cropping.");
            }

            using (var webClient = new WebClient())
            {
                byte[] imageBytes = await webClient.DownloadDataTaskAsync(command.ImagePath);
                byte[] croppedImage = ImageHelper.CropImage(imageBytes, Convert.ToInt32(command.CropPointX.Value), Convert.ToInt32(command.CropPointY.Value), Convert.ToInt32(command.ImageCropWidth.Value), Convert.ToInt32(command.ImageCropHeight.Value));

                string fileName = "crop_" + Guid.NewGuid() + Path.GetFileName(command.ImagePath);
                string cloudPath = string.Empty;
                try
                {
                    cloudPath = CloudFileHelper.SaveTempCroppedImageInCloud(fileName, croppedImage);
                }
                catch (Exception)
                {
                   
                    throw new Exception("Error while saving cropped image.");
                }

                return cloudPath;
            }
        }
    }
}
