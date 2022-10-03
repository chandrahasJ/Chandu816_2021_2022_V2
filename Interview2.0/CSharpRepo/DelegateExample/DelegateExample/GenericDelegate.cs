using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateExample
{
    public class GenericDelegate
    {
        private delegate void PrintDelegate(string msg);
        private delegate void MeaningLessDelegate();
        public static void Main()
        {            
            PrintDelegate printDelegate = (msg) => Console.WriteLine($"Via PrintDelegate => {msg}");
            printDelegate?.Invoke("Hi All");            
            //Action takes maximum of 16 input parameter & return type is always void
            Action<string> printAction = (msg) => Console.WriteLine($"Via Action<string> => {msg}");
            printAction("My Name is Chandrahas");            
            printAction?.Invoke("I am learning C#"); //Null Check 

            Console.WriteLine("-------------");
            MeaningLessDelegate meaningLessDelegate = () => Console.WriteLine($"Via meaningLessDelegate");
            meaningLessDelegate();

            //Action can also take zero parameters
            Action meaningLessAction = () => Console.WriteLine($"Via meaningLessAction");
            meaningLessAction();
            meaningLessAction?.Invoke(); //Null Check 

            Console.ReadLine();
        }
    }

    public class GenericDelegate2
    {
        private delegate double CalculateDelegate(int a, float b, double c);        
        public static void Main()
        {
            CalculateDelegate addDelegate = (x , y, z) =>  (double)(x + y + z);
            Console.WriteLine($"Via addDelegate :> {addDelegate?.Invoke(10,20.0f,30.0)}");

            //Func can take maximum of 16 input and 1 out parameter
            Func<int, float, double> multiplyFunc = (x, y) => (double)(x * y);
            Func<int, float, double, double> addFunc = (x, y, z) => (double)(x + y+ z);
            //Func can be treated as Predicate<int> 
            Func<int, bool> isGreaterThan5Func = (value) => (value > 5 ? true : false); 

            Console.WriteLine($"Via addFunc :> {addFunc?.Invoke(10, 20.0f, 30.0)}");
            Console.WriteLine($"Via multiplyFunc :> {multiplyFunc?.Invoke(10, 20.0f)}");
            Console.WriteLine($"Via isGreaterThan5Func :> {isGreaterThan5Func?.Invoke(10)}");
            Console.WriteLine($"Via isGreaterThan5Func :> {isGreaterThan5Func?.Invoke(4)}");

            Console.ReadLine();
        }
    }

    public class GenericDelegate3
    {
        private delegate bool IsGreateThan10Delegate(int number);
        public static void Main()
        {
            IsGreateThan10Delegate isGreateThan10Delegate = (number) => (number > 10 ? true : false);
            Console.WriteLine($"Via addDelegate :> {isGreateThan10Delegate?.Invoke(10)}");

            //Predicate only take 1 input parameter and always returns boolean.
            Predicate<int> isGreaterThan10Predicate = (number) => (number > 10 ? true : false);
            Predicate<string> isStringGreaterThan5Predicate = (stringvalue) => (stringvalue.Length > 10 ? true : false);

            Console.WriteLine($"Via isGreateThan10Predicate :> {isGreaterThan10Predicate?.Invoke(10)}");
            Console.WriteLine($"Via isStringGreaterThan5Predicate :> {isStringGreaterThan5Predicate?.Invoke("Hi Predicate")}");

            //Func can be treated as Predicate<int> 
            Func<int, bool> isGreaterThan5Func = (value) => (value > 5 ? true : false);
            Console.WriteLine($"Via isGreaterThan5Func :> {isGreaterThan5Func?.Invoke(10)}");

            Console.ReadLine();
        }
    }
}
