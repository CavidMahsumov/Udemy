﻿namespace Udemy.WebUI.Helper
{
    public class ImageHelper
    {
        private readonly IWebHostEnvironment _webhost;
        public ImageHelper(IWebHostEnvironment webhost)
        {
            _webhost = webhost;
        }
        public async Task<string> SaveFile(IFormFile file)
        {
            if (file != null)
            {
                var saveimg = Path.Combine(_webhost.WebRootPath, "Images", file.FileName);
                using (var img = new FileStream(saveimg, FileMode.Create))
                {
                    await file.CopyToAsync(img);
                }
                return file.FileName.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
