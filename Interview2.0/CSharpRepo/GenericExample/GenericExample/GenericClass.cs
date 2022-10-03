using System;
using System.Collections.Generic;
using System.Text;

namespace GenericExample
{
    public class GenericCalculatorClass<T>
    {
        public T Add(T a, T b)
        {
            dynamic a1 = a; dynamic b1 = b;
            return a1 + b1;
        }

        public T Sub(T a, T b)
        {
            dynamic a1 = a; dynamic b1 = b;
            return a1 - b1;
        }
    }
    public class TestGenericClass
    {
        public static void Main()
        {                        
            GenericCalculatorClass<float> genericCalculatorClassf
                                            = new GenericCalculatorClass<float>();
            Console.WriteLine($"Generic Class: Add float :> " +
                                            $"{genericCalculatorClassf.Add(10.25f, 6.5f)}");
            Console.WriteLine($"Generic Class: Sub float :>" +
                                            $" {genericCalculatorClassf.Sub(5.5f, 6.5f)}");

            GenericCalculatorClass<int> genericCalculatorClassi 
                                             = new GenericCalculatorClass<int>();
            Console.WriteLine($"Generic Class: Add int :> " +
                                             $"{genericCalculatorClassi.Add(10, 10)}");
            Console.WriteLine($"Generic Class: Sub int :>" +
                                             $" {genericCalculatorClassi.Sub(20, 10)}");
        }
    }

    public class GenericCalculator
    {
        public T Add<T>(T a, T b)
        {
            dynamic a1 = a; dynamic b1 = b;
            return a1 + b1;
        }

        public T Sub<T>(T a, T b)
        {
            dynamic a1 = a; dynamic b1 = b;
            return a1 - b1;
        }
    }

    public class GenericCalculatorMethod
    {
        public static void Main()
        {
            GenericCalculator genericCalculator = new GenericCalculator();
            Console.WriteLine($"Generic Method: Add :> " +
                $"{genericCalculator.Add<float>(10f, 10f)}");
            Console.WriteLine($"Generic Method: Sub :>" +
                $" {genericCalculator.Sub<int>(20, 10)}");
            Console.WriteLine($"Generic Method: Add :> " +
                $"{genericCalculator.Add<string>("Hello ", "CJ")}");
        }
    }
}
