    using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdvanceAsyncAwaitWebApp_Pitfalls.Controllers
{
    public class DontBlockTheThread : Controller
    {
        public IActionResult Index()
        {
            var task = GetDataFromInternet();

            // Below are the blocking operations
            // Bad Code 1 
            var a = task.Result;

            // Bad Code 2
            task.Wait();

            // Bad Code 3
            task.GetAwaiter().GetResult();

            return View();
        }

        /// <summary>
        /// Solution 
        /// Let your code propagate async await throught your code 
        /// </summary>
        public async Task<IActionResult> Index(int id)
        {
            // Async Await Started From GetDataFromInternet
            // and Ended on the Index method
            var task = await GetDataFromInternet();

            return View();
        }

        public async Task<string> GetDataFromInternet()
        {
            var client = new HttpClient();
            return await client.GetStringAsync("some site name"); ;
        }
    }
}
