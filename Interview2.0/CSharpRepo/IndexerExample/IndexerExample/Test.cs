using System;
using System.Collections.Generic;
using System.Text;

namespace IndexerExample
{
    
    class SampleCollection<T> 
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];

        // Define the indexer to allow client code to use [] notation.
        public T this[int i]
        {
            get => arr[i];
            set => arr[i] = value;
        }
    }

    class Program2
    {
        static void Main()
        {
            var stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World";            
            Console.WriteLine(stringCollection[0]);

            var employeeCollection = new SampleCollection<Employee>();
            employeeCollection[0] = new Employee(1001,"Chandrahas Poojari",3000000.00,
                                                 Department.Software,Designation.Sr_Enigneer);
            employeeCollection[1] = new Employee(1002, "Sunny", 3500000.00, 
                                                  Department.Software, Designation.Sr_Enigneer);
            Console.WriteLine($"Employee Data :> {employeeCollection[0]}");
            Console.WriteLine($"Employee Data :> {employeeCollection[1]}");
            Console.ReadLine();
        }
    }
}
