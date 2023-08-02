namespace Udemy.WebUI.Service.CloudinaryService
{
    public interface ICloudinaryService
    {
        Task<Uri> Upload(IFormFile image);
    }
}
