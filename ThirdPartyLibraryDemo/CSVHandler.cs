using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ThirdPartyLibraryAddressBook
{
    public class CSVHandler
    {
        public static void ImplimentatonDataHandling()
        {
            string ImportFilePath = @"C:\Users\Mihir Gautam\source\repos\ThirdPartyLibraryDemo\ThirdPartyLibraryDemo\Utility\Address.csv";
            string ExportFilePath = @"C:\Users\Mihir Gautam\source\repos\ThirdPartyLibraryDemo\ThirdPartyLibraryDemo\Utility\exports.csv";
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
                using (var writer = new StreamWriter(ExportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
            
    }
}
