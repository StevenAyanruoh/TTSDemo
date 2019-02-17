using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using FileHelpers;
using Newtonsoft.Json;

namespace TTSApp
{
    public static class ParseCSV
    {
        public static void run ()
        {
            try {

            
            String path = "county_facts_kaggle.csv";

            Console.WriteLine($"Path: {path}");

            CountyDataRecord [] records = parseCSV(path);

            List<CountyDataRecord> femaleMajority = new List<CountyDataRecord>();
            List<CountyDataRecord> femaleMinority = new List<CountyDataRecord>();

            buildDataSets(records, femaleMajority, femaleMinority);

            Console.Write("Female Majority to JSON:");  

            recordsToJSON(femaleMajority, "femaleMajority.json");
            recordsToJSON(femaleMinority, "femaleMinority.json");

            UploadCSVToS3.UploadCSV("Female Majority Dataset","femaleMajority.json");
            UploadCSVToS3.UploadCSV("Female Minority Dataset","femaleMinority.json");

            // DownloadCSVFromS3.DownloadCSV("Female Majority Dataset", "download_femaleMajority.json");
            // DownloadCSVFromS3.DownloadCSV("Female Minority Dataset", "download_femaleMinority.json");

            // DownloadCSVFromS3.printList();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Caught an exception: {e}");
            }

        }

        public static CountyDataRecord [] parseCSV(String path)
        {

                var engine = new FileHelperEngine<CountyDataRecord>();
                
                engine.BeforeReadRecord += (e, args) =>
                {
                    if (args.LineNumber == 1)
                        args.SkipThisRecord = true;
                };

                CountyDataRecord [] countyData = engine.ReadFile(path);

                return countyData;
                
        }

        public static List<FemaleDatasetRecord> parseFemaleDatasetJSON(String path)
        {
            
            dynamic dynJson = JsonConvert.DeserializeObject(File.ReadAllText(path));
             List<FemaleDatasetRecord>  data = new List<FemaleDatasetRecord>(); 
            foreach (var item in dynJson)
            {
                FemaleDatasetRecord rec = new FemaleDatasetRecord();
                rec.fips = item.fips;
                rec.area_name = item.area_name;
                rec.state_abbreviation = item.state_abbreviation;
                rec.SBO015207 = item.SBO015207;

                data.Add(rec);
            }
            return data;
                
        }    


        public static void buildDataSets(CountyDataRecord [] countyData, List<CountyDataRecord> femaleMajority,  
        List<CountyDataRecord> femaleMinority)
        {

            foreach (var record in countyData)
            {
                

                if(record.SEX255214 > new decimal (50.0))
                {
                    femaleMajority.Add(record);
                }
                else if (record.SEX255214 < new decimal (50.0))
                {
                    femaleMinority.Add(record);
                }
                else
                {
                    // do nothing for the moment
                }

                
            }
        }
        public static void recordsToJSON(List<CountyDataRecord> records, String outputPath)
        {

            MemoryStream stream1 = new MemoryStream();  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CountyDataRecord));  

            foreach (var record in records)
            {
                ser.WriteObject(stream1, record); 
            }

            stream1.Position = 0;  
            StreamReader sr = new StreamReader(stream1);  

            //Wrtie result to file
            Console.Write("JSON form of CountyDataRecord object: ");  
            StreamWriter file = File.CreateText(outputPath);
            file.Write(sr.ReadToEnd());
            Console.WriteLine(sr.ReadToEnd()); 
            file.Close();
            sr.Close();
        }
        
    }
}
