using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamingFileFromData
{
    public class DataClass
    {
        string FilePath = @"F:\LearningPath\WPF\FullStackWPF";
        string[] data =
        {
            "Domain Introduction and Entity Framework Setup - FULL STACK WPF (.NET CORE) MVVM #1",

        "Entity Framework CRUD - FULL STACK WPF (.NET CORE) MVVM #2",

        "WPF in .NET Core and MVVM Navigation - FULL STACK WPF (.NET CORE) MVVM #3",

        "API Service Calls and Async ViewModel Loading - FULL STACK WPF (.NET CORE) MVVM #4",

        "Adding an API Key (App.config Setup) - FULL STACK WPF (.NET CORE) MVVM #4.1",

        "Styling the Navigation Bar - FULL STACK WPF (.NET CORE) MVVM #5",

        "Creating a Card Control - FULL STACK WPF (.NET CORE) MVVM #6",

        "Fetching Stock Prices and Refactoring API Calls - FULL STACK WPF (.NET CORE) MVVM #7",

        "Inserting User Data with Entity Framework Core - FULL STACK WPF (.NET CORE) MVVM #8",

        "Dependency Injection Setup - FULL STACK WPF (.NET CORE) MVVM #9",

        "Creating the ViewModel and View for Buying Stocks - FULL STACK WPF (.NET CORE) MVVM #10",

        "Dynamic Views and Custom Element Styles - FULL STACK WPF (.NET CORE) MVVM #11",

        "User Authentication (Login/Registration) Service - FULL STACK WPF (.NET CORE) MVVM #12",

        "Unit Testing the Authentication Service (with NUnit and Moq) - FULL STACK WPF (.NET CORE) MVVM #13",

        "Integrating Authentication with the WPF Application - FULL STACK WPF (.NET CORE) MVVM #14",

        "Creating a Login Form in WPF - FULL STACK WPF (.NET CORE) MVVM #15",

        "Navigating Between Views - FULL STACK WPF (.NET CORE) MVVM #16",

        "Using Delegates as View Model Factories - FULL STACK WPF (.NET CORE) MVVM #17",

        "Account State Management - FULL STACK WPF (.NET CORE) MVVM #18",

        "Using LINQ to Calculate User Transaction Data - FULL STACK WPF (.NET CORE) MVVM #19",

        "ListView w/ GridView and Finishing the Home View - FULL STACK WPF (.NET CORE) MVVM #20",

        "Handling Exceptions and Messages - FULL STACK WPF (.NET CORE) MVVM #21",

        ".NET Core Generic Host w/ Entity Framework Migrations - FULL STACK WPF (.NET CORE) MVVM #22",

        "View Model, View, and Navigation for User Registration - FULL STACK WPF (.NET CORE) MVVM #23",

        "Creating Reusable Controls - FULL STACK WPF (.NET CORE) MVVM #24",

        "Completing the Domain Layer (w/ Unit Testing) - FULL STACK WPF (.NET CORE) MVVM #25",

        "Configuring SQLite w/ Entity Framework Core - FULL STACK WPF (.NET CORE) MVVM #26",

        "Reusing Commands & Implementing the Sell View/ViewModel - FULL STACK WPF (.NET CORE) MVVM #27",

        "Clean Dependency Injection Setup w/ Extension Methods - FULL STACK WPF (.NET CORE) MVVM #28",

        "Using HttpClient Best Practices - FULL STACK WPF (.NET CORE) MVVM #29",

        "Porting to .NET 5 - FULL STACK WPF (.NET CORE) MVVM #30",

        "Disposing View Models - FULL STACK WPF (.NET CORE) MVVM #31",

        "Toggling Form Submission - FULL STACK WPF (.NET CORE) MVVM #32",

        "Loading Status and Command - FULL STACK WPF (.NET 5) MVVM #33"
        };

        public void changeTheFileName()
        {
            string [] fileData = Directory.GetFiles(FilePath,"*.mp4");
            int i = 0;
            foreach (var item in data)
            {
                string newfileName = item.Replace("|", "_").Replace(" ", "_") + "(1080p).mp4";
                string newFilePath = FilePath + "\\" + newfileName;
                FileInfo f = new FileInfo(newFilePath);
                if (f.Exists)
                {
                    i++;
                    string fileName = FilePath+"\\"+i + "_" + newfileName;
                    f.Rename(fileName);
                    Console.WriteLine("Done with File Numberiing -"+fileName);
                    //f.Delete();
                }
            }
            
        }

        public void ChangeTheFileNameV2()
        {
            string[] fileData = Directory.GetFiles(FilePath, "*.mp4");
            int i = 0;
            foreach (var item in fileData)
            {
                string[] levelOne = item.Replace("(1080p).mp4", "").Split('#');
                if (levelOne.Length > 1)
                {
                    
                    FileInfo f = new FileInfo(item);
                    string newFileName = FilePath + "\\" + levelOne[1] + "_" + f.Name;
                    f.Rename(newFileName);
                    Console.WriteLine("Done with File Numberiing -" + newFileName);
                    //f.Delete();

                }
            }
        }
    }

    public static class FileInfoExtensions
    {
        public static void Rename(this FileInfo fileInfo, string newName)
        {
            fileInfo.MoveTo(Path.Combine(fileInfo.Directory.FullName, newName));
        }
    }
}
