namespace Udemy.WebUI.Service
{
    public interface IStorageService
    {
        Task UploadPhoto(IFormFile file);
    }
}
