using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TTSApp
{
    public static class DownloadCSVFromS3
    {
        private const string bucketName = "jd-tts-demo";        
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        
        private static IAmazonS3 s3Client;

        public static List<S3Object> res;

        private static IAmazonS3 getS3Client()
        {
            
            if( s3Client == null)
            {
                s3Client = new AmazonS3Client(bucketRegion);
            }

            return s3Client;
        }

        static async Task ListingObjectsAsync(List<S3Object> res)
        {
            
                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = bucketName
                    
                };
                ListObjectsV2Response response;
                do
                {
                    response = await getS3Client().ListObjectsV2Async(request);

                    // Process the response.
                    foreach (S3Object entry in response.S3Objects)
                    {
                        // Console.WriteLine("key = {0} size = {1}",
                        //     entry.Key, entry.Size);
                        res.Add(entry);
                    }
                    Console.WriteLine("Next Continuation Token: {0}", response.NextContinuationToken);
                    request.ContinuationToken = response.NextContinuationToken;
                } while (response.IsTruncated);



            return;
        }

        public static void DownloadCSV(string keyName, string outputPath)
        {
            ReadObjectData(keyName, outputPath);
        }

        public static List<S3Object> getBucketList()
        {
            res = new List<S3Object>();
            ListingObjectsAsync(res).Wait();

            return res;
        }

        static void ReadObjectData(string keyName, string outputPath)
        {

            try
            {
                var fileTransferUtility =
                new TransferUtility(getS3Client());

                // Option 2. Specify object key name explicitly.
                fileTransferUtility.Download(outputPath, bucketName, keyName);
                Console.WriteLine("Downlaod completed");

            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered ***. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
        }
    }
}