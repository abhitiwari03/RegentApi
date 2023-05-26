using AutoMapper;
using MediatR;
using RegentApi.DTO;
using RegentApi.Helpers;
using RegentApi.Models;
using System.Web.Helpers;

namespace RegentApi.Services.Command
{
    public class UploadCoverPictureCommand : IRequest<UploadCoverPicture>
    {
        public IFormFile? FU1 { get; set; }

    }
    public class uploadpicturehandler : IRequestHandler<UploadCoverPictureCommand, UploadCoverPicture>
    {
        private readonly RegentDB_NewContext m_context;
        private readonly IMapper m_mapper;
        private readonly IMediator m_mediator;
        public uploadpicturehandler(RegentDB_NewContext context, IMapper mapper, IMediator mediator)
        {
            m_context = context;
            m_mapper = mapper;
            m_mediator = mediator;
        }
        public async Task<UploadCoverPicture> Handle(UploadCoverPictureCommand command, CancellationToken cancellationToken)
        {
            if (command.FU1 != null)
            {
                var imgRe = new WebImage(command.FU1.OpenReadStream());

                int width = imgRe.Width;
                int height = imgRe.Height;
                var userMessage = string.Empty;


                string ext = Path.GetExtension(command.FU1.FileName).ToLower();

                if (ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".png")
                {
                    userMessage = "Please choose an image. Only files with .jpg, .jpeg, .gif, and .png extensions are allowed.";

                    return new UploadCoverPicture("", userMessage, 1);


                }

                // Maintain 5:3 ratio with image size between 600x360 - 800x480
                if (width < 600 || height < 360)
                {
                    userMessage = "Image smaller than 600x360 is not allowed. Please select a bigger image.";
                    return new UploadCoverPicture("", userMessage, 2);
                }


                string pic = $"{Guid.NewGuid()}{Path.GetExtension(command.FU1.FileName).ToLower()}";
                string cloudPath = CloudFileHelper.SaveTempImageInCloud(pic, imgRe);

                // If the image is bigger than 1200x1200 size, give cropping suggestion
                if (width > 1200 || height > 1200)
                {
                    userMessage = "The image is bigger than 1200x1200 pixels which might make the site slow.";
                    return new UploadCoverPicture("", userMessage, 3);

                }
                else
                {
                    return new UploadCoverPicture(cloudPath, "size should be in proper size", 4);

                }

            }
            return new UploadCoverPicture("", "File could not be read. Please try again.", 3);

        }

    }
}
 

