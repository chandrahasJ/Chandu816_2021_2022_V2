using System;
using System.Collections.Generic;

namespace GenericCollectionsInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstData = new List<int>() { 50,10,5,45,8,100,2,1 };
            lstData.Sort();
            foreach (var item in lstData)
                Console.Write($"{item}\t");
        }
    }
}
