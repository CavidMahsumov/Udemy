using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Udemy.WebUI.Service.CloudinaryService
{
    public class CloudinaryService:ICloudinaryService
    {

        Cloudinary cloudinary = new Cloudinary(new Account("dkeckqqcp", "858845549972217", "WxuIdzk_BkZWH1GMu-acmBR4cd8"));

        public async Task<Uri> Upload(IFormFile image)
        {
            var result = await cloudinary.UploadAsync(new ImageUploadParams
            {
                File = new FileDescription(image.FileName,
                        image.OpenReadStream())
            });
            return result.Url;
        }
    }
}
