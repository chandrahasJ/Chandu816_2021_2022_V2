using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.EFCore;
using SimpleTraderApp.EFCore.Services;
using System;
using System.Linq;

namespace SimpleTraderConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IDataService<User> dataService = new GenericDataService<User>(new SimpleTraderAppDbContextFactory());
            Console.WriteLine(dataService.GetAll().Result.Count());
            dataService.Create(new User()
            {
                UserName = "Test 2"
            }).Wait();

            Console.WriteLine(dataService.GetAll().Result.Count());

            Console.WriteLine(dataService.Get(1).Result);

            Console.WriteLine(dataService.Update(1, new User() {  UserName = "Test", Email = "c@p.com", DateJoined = DateTime.Now}).Result);

            Console.WriteLine(dataService.Delete(2).Result);

            Console.WriteLine(dataService.GetAll().Result.Count());

            Console.ReadLine();
        }
    }
}
