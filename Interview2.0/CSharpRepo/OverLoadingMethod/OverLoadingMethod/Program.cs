using System;

namespace OverLoadingMethod
{
    class Program
    {
        public void Test() { Console.WriteLine("Test"); }
        public string Test() { Console.WriteLine("Test with diff return type"); }
        public void Test(int i) { Console.WriteLine("Test with int"); }
        public void Test(string s) { Console.WriteLine("Test with string"); }
        public void Test(string s, int i) { Console.WriteLine("Test with string, int"); }
        public void Test(int i, string s) { Console.WriteLine("Test with int, string"); }
        //Below is not allowed - return type  
        //public string Test() { Console.WriteLine("This function is invalid. Ambiguity issue."); }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program p = new Program();
            p.Test();
            p.Test(10); p.Test("String");
            p.Test("string", 10); p.Test(10, "String");
            Console.ReadLine();
        }
    }
}
