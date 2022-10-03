using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionExample
{
    public class HashTableExample
    {
        public static void Display(Hashtable hashtable)
        {
            //Keys are stored in hashcode for retrieving data faster
            foreach (var key in hashtable.Keys)
                Console.WriteLine($"{key} : {hashtable[key]} - " +
                    $"Hashcode : {key.GetHashCode()}");
            Console.WriteLine("---------------------------------");
        }
        public static void Main()
        {
            //Key can be numeric, alphanumeric in hashtable
            Hashtable hashtableNumericKey = new Hashtable();
            hashtableNumericKey.Add(0,"Test Data");
            hashtableNumericKey.Add(1, "Test Data 2");
            Display(hashtableNumericKey);

            Hashtable htEmployee = new Hashtable();
            htEmployee.Add("EmpId",1860);
            htEmployee.Add("EmpName", "Chandrahas Poojari");
            htEmployee.Add("Job", "Sr. Software Dev.");
            htEmployee.Add("Salary", 100000000000);
            htEmployee.Add("Phone", 9858528525);
            htEmployee.Add("MrgId", 1000);
            Display(htEmployee);

            //Removing the key from hashtable
            htEmployee.Remove("Phone");
            Display(htEmployee);
            //Accessing values via key 
            Console.WriteLine($"Emp Name : {htEmployee["EmpName"]} \n" +
                              $"Emp Job  : {htEmployee["EmpName"]} \n" +
                              $"Salary   : {htEmployee["Salary"]}");

        }
    }
}
