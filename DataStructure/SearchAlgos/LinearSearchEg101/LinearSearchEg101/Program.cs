using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSearchEg101
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayData = { 84, 56, 85, 21, 10, 98, 78, 7452, 11, 963 , -100};
            Search search = new Search();
            int searchFor = 10;
            int searchIndex = -1;
            string searchResult = search.linearSearch(arrayData, arrayData.Length, searchFor, out searchIndex) == -1 ? "Not Found" : "Found";
            Console.WriteLine($"Searching for {searchFor} ... Result : {searchResult} on index { searchIndex}");

            searchFor = 963;
            searchResult = search.linearSearch(arrayData, arrayData.Length, searchFor, out searchIndex) == -1 ? "Not Found" : "Found";
            Console.WriteLine($"Searching for {searchFor} ... Result : {searchResult} on index { searchIndex}");

            searchFor = -100;
            searchResult = search.linearSearch(arrayData, arrayData.Length, searchFor, out searchIndex) == -1 ? "Not Found" : "Found";
            Console.WriteLine($"Searching for {searchFor} ... Result : {searchResult} on index { searchIndex}");

            searchFor = 100;
            searchResult = search.linearSearch(arrayData, arrayData.Length, searchFor, out searchIndex) == -1 ? "Not Found" : "Found";
            Console.WriteLine($"Searching for {searchFor} ... Result : {searchResult} on index { searchIndex}");

            Console.ReadLine();
        }
    }
}
