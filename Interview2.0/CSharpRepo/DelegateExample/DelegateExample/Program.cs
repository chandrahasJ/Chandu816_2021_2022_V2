using System;

namespace DelegateExample
{
    //Step-1) Defining the a Delegate
    public delegate void AddDelegate(int x, int y);
    public delegate string SayDelegate(string str);
    class Program
    {
        public void AddNums(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        public static string SayHello(string name)
        {
            return "Hello " + name;
        }
        static void Main(string[] args)
        {
            Program program = new Program();

            //Step-2) Instantiating the delegate
            AddDelegate addDelegate = new AddDelegate(program.AddNums);
            SayDelegate sayDelegate = Program.SayHello;

            //Step-3) Calling the method via delegate
            addDelegate(200, 50);  addDelegate.Invoke(100, 50);          
            Console.WriteLine(sayDelegate("Chandrika"));
            Console.WriteLine(sayDelegate.Invoke("Suraj"));
            Console.ReadLine();
        }
    }
}
