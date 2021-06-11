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
        string FilePath = @"<Add Your Path>";
        string[] data =
        {
            "Angular and ASP.NET Core Web API Course | Learn by building real application | Free Tutorial",

            "Angular Project Setup and Version History | Angular Tutorial",

            "What has changed from Angular 9 (Major Release)",

            "Folder structure and flow of angular application | Angular Tutorial",

            "Important Angular Extensions and multiple ways to create components",

            "Component workflow and create property card component",

            "What is GIT and GIT Hub",

            "Create property list",

            "Add CSS animation to Property Card",

            "Using Service and HTTP calls in Angular 9",

            "Modify HTTP Data using Pipe",

            "Understand Routing - Part-1",

            "Understand Routing - Part 2",

            "Understand Routing - Part 3",

            "Template Driven Forms in Angular",

            "Reactive Forms in angular",

            "5 Reasons I love to use Reactive forms",

            "Save Data to Local Storage in Angular | Angular Tutorial",

            "Add alertify notifications as service",

            "Add Login Logout Functionality",

            "Design add new property form",

            "Enhance add new property form",

            "Save new property and display on list page",

            "Saving multiple properties",

            "Migrate from Angular 9 to 10 & Create Property Detail view",

            "Add Route Resolver and Image Gallery",

            "Add Filtering and Sorting using angular pipes",

            "Deploy Angular Application to Firebase hosting for free",

            "Build a Web API using ASP.Net Core",

            "Create WebAPI Project",

            "Consuming WebAPI in Angular",

            "Create DB and fetch data using EF Core Code First Approach",

            "Implement add and delete operation in WebAPI",

            "Using Repository Pattern",

            "Using Unit of Work Pattern",

            "Why to use DTO (Data Transfer Objects)",

            "Using Automapper in C#",

            "HTTP Put vs Patch for update",

            "Input validation and exception handling in ASP.NET Web API",

            "Handling Errors Globally in ASP .NET Core Web API",

            "Add more features to Custom Middleware",

            "What is JWT and why should you use JWT in WebAPI",

            "Authenticate user with user id and password",

            "Create JWT in ASP.NET Core and use it for Authorization",

            "How to manage user secrets in dot net core",

            "Protect passwords with hashing and salting",

            "Deploy API on Azure",

            "Deploy Angular App on Azure",

            "Deploy Angular and Dot Net Core Web API on IIS",

            "Migrate from Angular 10 to Angular 11",

            "Migrating from TSLint to ESLint is a pain | Problems and Solutions",

            "Hookup login and register component to Web API | Angular Free Tutorial",

            "Global error handling in angular using interceptor | Free Angular Tutorial",

            "Using retry and retryWhen in Angular for failed requests | Angular Tutorial",

            "Add Property Related Entities | Define relationship between entities",

            "Database seeding in Entity Framework Core | Angular + WebAPI Tutorial",

            "Integrate property list page to web API | Angular Tutorial",

            "Hookup Property Detail view to WebAPI",

            "Populate Possession Date on Property Card",

            "Hookup Add Property Page to WebAPI - Part 1 | Angular Tutorial"

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
    }

    public static class FileInfoExtensions
    {
        public static void Rename(this FileInfo fileInfo, string newName)
        {
            fileInfo.MoveTo(Path.Combine(fileInfo.Directory.FullName, newName));
        }
    }
}
