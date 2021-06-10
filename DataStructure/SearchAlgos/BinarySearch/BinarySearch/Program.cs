using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchAlgo bs = new BinarySearchAlgo();
            int[] ArrayData = { 15, 26, 95, 100, 106, 500, 589, 700, 896, 999 };
            foreach (var item in ArrayData)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
            int searchItem = 26;
            int found = bs.BinarySearch(ArrayData, ArrayData.Length, searchItem);
            Console.WriteLine($"Result for {searchItem}: " + found);

            searchItem = 106;
            found = bs.BinarySearch(ArrayData, ArrayData.Length, searchItem);
            Console.WriteLine($"Result for {searchItem}: " + found);

            searchItem = 700;
            found = bs.BinarySearch(ArrayData, ArrayData.Length, searchItem);
            Console.WriteLine($"Result for {searchItem}: " + found);

            searchItem = 1000;
            found = bs.BinarySearch(ArrayData, ArrayData.Length, searchItem);
            Console.WriteLine($"Result for {searchItem}: " + found);

            searchItem = 500;
            found = bs.BinarySearch(ArrayData, ArrayData.Length, searchItem);
            Console.WriteLine($"Result for {searchItem}: " + found);


            Console.ReadLine();

        }
    }
}
