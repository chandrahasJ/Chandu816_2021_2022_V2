using System;

namespace AdvanceGenericExample
{
    //Process Data 2 is extended using generic delegate
    public class ProcessData2 
    {
        public void Process(string data, Action<string> action)
        {
            action(data);
        }
    }
    class Program2
    {
        public static void RemoveNumbers(string data)
        { Console.WriteLine("Remove Numbers"); }
        public static void Main()
        {
            string data = "Chandrahas_Poojari  816    ";
            ProcessData2 processData2 = new ProcessData2();
            Process process = new Process();
            Action<string> actionForProcessingString = process.RemoveSpace;
            actionForProcessingString += process.RemoveUnderScore;
            actionForProcessingString += RemoveNumbers;
            processData2.Process(data, actionForProcessingString);
        }
    }
    public class ProcessData //Process Data is extended using delegate
    {
        public delegate void ProcessDataDelegate(string data);
        public void Process(string data,
                                ProcessDataDelegate processDataDelegate)
        {
            processDataDelegate(data);
        }
    }
    class Program
    {
        public static void RemoveNumbers(string data)
        { Console.WriteLine("Remove Numbers"); }
        static void Main(string[] args)
        {
            string data = "Chandrahas_Poojari  816    ";
            ProcessData processData = new ProcessData();
            Process process = new Process();
            ProcessData.ProcessDataDelegate processDataDelegate = process.RemoveSpace;
            processDataDelegate += process.RemoveUnderScore;
            processDataDelegate += RemoveNumbers;
            processData.Process(data, processDataDelegate);
        }
    }
}
