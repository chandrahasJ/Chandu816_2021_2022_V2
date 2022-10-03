using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhereDoesTaskStart
{
    class Program
    {
        List<Task> list = new List<Task>();
        //We need to keep out main non Task
        static void Main(string[] args)
        {
            // if you are awaiting inside StartApp 
            // StartApp();

            //Else So now you app is progragating properly 
            // Main - is the blocking thread and non task method.
            StartApp().GetAwaiter().GetResult();

        }

        private static Task StartApp()
        {
            var collectDataFromWeb = CollectDataFromWeb();
            var processDataFromCollectedData = ProcessDataFromCollectedData();
            var taskCollection = new Task[] { collectDataFromWeb, processDataFromCollectedData};

            // We can do it but we should wait in the root method where it all started
            //Task.WaitAll(taskCollection); 

            return Task.WhenAll(taskCollection);
        }

        private static Task ProcessDataFromCollectedData()
        {
            while (true)
            {
                // read the files and save it in the database.
                if (true)
                {
                    string fileName = "ProcessedFileName";
                    // Saving in the database was successfull then call
                    // Update logs.
                    // Fire and Forget
                    Task.Run(() => UpdateLogs(fileName));
                }
            }
        }

        private static Task CollectDataFromWeb()
        {
            while (true)
            {
                // Download data from web and save it in the file.
            }
        }

        private static Task UpdateLogs(string fileName)
        {
            // Save the data in the logs
            return Task.CompletedTask;
        }
    }
}
