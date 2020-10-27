using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ThirdPartyLibraryAddressBook
{
    class JSONcsvManipulation
    {
        public static void ImplimentCSVtoJSON() 
        {
            string ImportFilePath = @"C:\Users\Mihir Gautam\source\repos\ThirdPartyLibraryDemo\ThirdPartyLibraryDemo\Utility\Address.csv";
            string ExportFilePath = @"C:\Users\Mihir Gautam\source\repos\ThirdPartyLibraryDemo\ThirdPartyLibraryDemo\addressDetails.json";
            using (var reader = new StreamReader(ImportFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Data reading done successfully from address.csv file");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.FirstName);
                    Console.Write("\t" + addressData.LastName);
                    Console.Write("\t" + addressData.City);
                    Console.Write("\t" + addressData.Address);
                    Console.Write("\t" + addressData.State);
                    Console.Write("\t" + addressData.Code);
                    Console.Write("\n");
                }

                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(ExportFilePath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, records);
                }
            }
        }
        public static void ImplimentJSONtoCSV()
        {
            string ExportFilePath = @"C:\Users\Mihir Gautam\source\repos\ThirdPartyLibraryDemo\ThirdPartyLibraryDemo\addressDetails.csv";
            string ImportFilePath = @"C:\Users\Mihir Gautam\source\repos\ThirdPartyLibraryDemo\ThirdPartyLibraryDemo\addressDetails.json";
            IList<AddressData> addressDatas = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(ImportFilePath));
            using (var writer = new StreamWriter(ExportFilePath))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords(addressDatas);
            }
        }
        }
    }
