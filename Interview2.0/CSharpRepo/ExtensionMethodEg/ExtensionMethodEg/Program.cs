using System;

namespace ExtensionMethodEg
{
    class Program //Assume Source code is not avaliable 
    {
        // Preferance wil be given to OG method
        public void Test1() { Console.WriteLine("Test1 Method"); } 
    }
    static class ExtendProgram  //Extension Class
    {
        //Same name and Signature of Extension method 
        public static void Test1(this Program p) { Console.WriteLine("Extended Test1 Method"); }
    }
    public class TestProgram
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Test1();
            Console.ReadLine();
        }
    }
}
