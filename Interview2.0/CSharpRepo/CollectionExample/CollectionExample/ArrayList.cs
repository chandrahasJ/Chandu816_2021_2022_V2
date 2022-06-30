using System;
using System.Collections;
namespace CollectionExample
{
    class ArrayList
    {
        public static void displayArrayList(System.Collections.ArrayList arrayList)
        {
            foreach (var item in arrayList)
                Console.Write($"{item} \t");
            Console.WriteLine();             
        }
        static void Main(string[] args)
        {
            //ArrayList Declared with with initial capacity as 2
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList(2); 
            Console.WriteLine("Inital Capacity "+arrayList.Capacity);
            arrayList.Add(100); arrayList.Add(200); arrayList.Add(300);
            Console.WriteLine("After adding 3 item. Capacity " + arrayList.Capacity);
            arrayList.Add(400); arrayList.Add(500); arrayList.Add(600); 
            arrayList.Add(700);
            Console.WriteLine("After adding 7 item. Capacity " + arrayList.Capacity);
            arrayList.Add(800); arrayList.Add(900);
            Console.WriteLine("After adding 9 item. Capacity " + arrayList.Capacity);

            displayArrayList(arrayList);
            //Inserting items in the middle of ArrayList
            arrayList.Insert(5, 550);
            displayArrayList(arrayList);
            //Remove/Deleting items from the middle of the ArrayList
            arrayList.Remove(400);
            displayArrayList(arrayList);
            arrayList.RemoveAt(6);
            displayArrayList(arrayList);
            Console.ReadLine();
        }
    }
}
