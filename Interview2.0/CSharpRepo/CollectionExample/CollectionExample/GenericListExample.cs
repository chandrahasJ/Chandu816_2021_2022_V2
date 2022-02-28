using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionExample
{
    public class GenericListExample
    {
        public static void Display(List<int> lsts)
        {
            foreach (var item in lsts)
                Console.Write(item + " ");
            Console.WriteLine();
        }
        public static void Main()
        {
            int[] int_arr = { 30, 40, 50, 60 };
            List<int> lstOfIntergers = new List<int>();
            lstOfIntergers.Add(10); lstOfIntergers.Add(20);
            lstOfIntergers.AddRange(int_arr);

            for (int i = 0; i < lstOfIntergers.Count; i++)
                Console.Write(lstOfIntergers[i] + " ");
            Console.WriteLine();

            lstOfIntergers.Insert(4, 55);
            Display(lstOfIntergers);

            lstOfIntergers.RemoveAt(1);
            Display(lstOfIntergers);

            lstOfIntergers.Remove(10);
            Display(lstOfIntergers);
            Console.ReadLine();
        }
    }
}
