using System;
using ThirdPartyLibraryAddressBook;

namespace ThirdPartyLibraryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CSVHandler.ImplimentatonDataHandling();
            //JSONcsvManipulation.ImplimentCSVtoJSON();
            JSONcsvManipulation.ImplimentJSONtoCSV();
        }
    }
}
