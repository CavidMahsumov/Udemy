namespace Udemy.WebUI.Service
{
    public interface IStorageService
    {
        Task<Uri> UploadPhoto(IFormFile file);
    }
}
