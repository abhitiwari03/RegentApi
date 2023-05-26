using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using RegentApi.Models;
using Microsoft.Extensions.Configuration;
using System.Web.Helpers;

namespace RegentApi.Helpers
{
    


        public enum UploadType
        {
            LargeImage,
            SmallImage,
            Document
        }

        public enum CloudContainer
        {
            documents,
            images,
            temp
        }
        public static class CloudFileHelper
        {



            /// <summary>
            /// Saves the file in cloud temporarily for image editing
            /// </summary>
            /// <param name="fileName">File Name with extension</param>
            /// <param name="imgRe">Web Image that needs to be stored</param>
            /// <returns>Temp file path</returns>
            public static string SaveTempImageInCloud(string fileName, WebImage imgRe)
            {
                try
                {
                    //Get reference to containers
                    CloudBlobContainer container = GetContainerReference("temp");

                    //Upload file to cloud
                    CloudBlockBlob tempFile = container.GetBlockBlobReference(fileName);
                    byte[] imgBytes = imgRe.GetBytes();

                    using (MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length))
                    {
                        tempFile.UploadFromStreamAsync(ms);
                    }

                    return tempFile.StorageUri.PrimaryUri.AbsoluteUri;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /// <summary>
            /// Saves the cropped image in cloud temporarily
            /// </summary>
            /// <param name="fileName"></param>
            /// <param name="imgBytes"></param>
            /// <returns></returns>
            public static string SaveTempCroppedImageInCloud(string fileName, byte[] imgBytes)
            {
                try
                {
                    //Get reference to container
                    CloudBlobContainer container = GetContainerReference("temp");

                    //Upload file to cloud
                    CloudBlockBlob tempFile = container.GetBlockBlobReference(fileName);

                    using (MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length))
                    {
                        tempFile.UploadFromStreamAsync(ms);
                    }

                    return tempFile.StorageUri.PrimaryUri.AbsoluteUri;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        public class YourHelperClass
        {
            private readonly IConfiguration _configuration;

            public YourHelperClass(IConfiguration configuration)
            {
                _configuration = configuration;
            }
        }
            public static CloudBlobContainer GetContainerReference(string containerName, bool createMissingContainer = true)
            {

                string storageConnectionString = _configuration["StorageConnectionString"];

                if (string.IsNullOrEmpty(storageConnectionString))
                {
                    throw new ApplicationException("Azure storage connection string is not defined in configuration");
                }

                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                //if (string.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("StorageConnectionString")))
                //    throw new ApplicationException("Azure storage connection string is not defined in configuration");

                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings.Get("StorageConnectionString"));

                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                //Get reference to containers
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);

                if (createMissingContainer)
                {
                    // Create the container if it doesn't already exist.
                    container.CreateIfNotExistsAsync();

                    //set permissions for blobs
                    var perm = new BlobContainerPermissions();
                    perm.PublicAccess = BlobContainerPublicAccessType.Blob;
                    container.SetPermissionsAsync(perm);
                }

                return container;
            }


        }
    }

