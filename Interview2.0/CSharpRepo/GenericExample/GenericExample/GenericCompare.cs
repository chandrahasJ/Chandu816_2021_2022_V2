using System;
using System.Collections.Generic;
using System.Text;

namespace GenericExample
{

    class GenericCompare
    {
        public bool Compare<T>(T a, T b)
        {
            if (a.Equals(b))
                return true;
            return false;
        }

        public static void Main()
        {
            GenericCompare genericCompare = new GenericCompare();
            bool result = genericCompare.Compare<int>(10, 50);
            Console.WriteLine("Result :> " + result);

            result = genericCompare.Compare<string>("a", "a");
            Console.WriteLine("Result :> " + result);

            // Below code gives me compile time error 
            // Since we have specfied that we need to 
            // compare float values it is not allowring 
            // double value 

            //result = genericCompare.Compare<float>(10.25f, 50.25);
            //Console.WriteLine("Result :> " + result);
            Console.ReadLine();
        }
    }

    class NonGenericCompare
    {
        public bool Compare(object a, object b)
        {
            if (a.Equals(b))
                return true;
            return false;
        }

        public static void Main()
        {
            NonGenericCompare nonGenericCompare = new NonGenericCompare();
            bool result = nonGenericCompare.Compare(10, 50);
            Console.WriteLine("Result :> "+result);

            result = nonGenericCompare.Compare(10f, 10f);
            Console.WriteLine("Result :> " + result);

            // I wanted to compare float & float 
            // but it works since it is not type safe
            result = nonGenericCompare.Compare(10.25f, 25.50);
            Console.WriteLine("Result :> " + result);
            Console.ReadLine();
        }
    }
}
