using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace TTSApp
{
    static class UploadCSVToS3
    {
        private const string bucketName = "jd-tts-demo";
        
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;

        private static IAmazonS3 s3Client;

        private static IAmazonS3 getS3Client()
        {
            
            if( s3Client == null)
            {
                s3Client = new AmazonS3Client(bucketRegion);
            }

            return s3Client;
        }

        public static void UploadCSV(string keyName, string filePath)
        {
            UploadFileAsync(keyName, filePath).Wait();
        }

        private static async Task UploadFileAsync(string keyName, string filePath)
        {
            try
            {
                var fileTransferUtility =
                    new TransferUtility(getS3Client());

                // Option 2. Specify object key name explicitly.
                await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
                Console.WriteLine("Upload completed");
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

        }

    }
}