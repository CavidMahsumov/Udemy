﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Udemy.WebUI.Service
{
    public class StorageService : IStorageService
    {
        private readonly IConfiguration _configuration;

        public StorageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Uri> UploadPhoto(IFormFile file)
        {

            string systemFileName = file.FileName;
            string blobstorageconnection = _configuration.GetValue<string>("ConnectionString");
            // Retrieve storage account from connection string.    
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            // Create the blob client.    
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            // Retrieve a reference to a container.    
            CloudBlobContainer container = blobClient.GetContainerReference(_configuration.GetValue<string>("ContainerName"));
            // This also does not make a service call; it only creates a local object.    
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);
            await using (var data = file.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }
            CloudBlockBlob blob = container.GetBlockBlobReference(file.FileName);
            return blob.Uri;




        }
    }
}
