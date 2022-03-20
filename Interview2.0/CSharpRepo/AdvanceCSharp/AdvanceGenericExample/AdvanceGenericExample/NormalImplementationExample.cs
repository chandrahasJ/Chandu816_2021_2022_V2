using System;
using System.Collections.Generic;
using System.Text;

namespace AdvanceGenericExample
{
    public class Process
    {
        public void RemoveSpace(string data)
        { Console.WriteLine("Removing Space :)" + data); }
        public void RemoveUnderScore(string data)
        { Console.WriteLine("Removing UnderScore :)" + data); }
    }
    //Process Data 2 is extended using generic delegate
    public class ProcessData0
    {
        public void Process(string data)
        {
            Process process = new Process();
            process.RemoveSpace(data);
            process.RemoveUnderScore(data);
        }
    }
    class Program0
    {
        public static void RemoveNumbers(string data)
        { Console.WriteLine("Remove Numbers"); }
        public static void Main()
        {
            string data = "Chandrahas_Poojari  816    ";
            ProcessData0 process = new ProcessData0();
            process.Process(data);
            // So now if you want to extended the functionality
            // it would be cumbersome 
        }
    }
}
