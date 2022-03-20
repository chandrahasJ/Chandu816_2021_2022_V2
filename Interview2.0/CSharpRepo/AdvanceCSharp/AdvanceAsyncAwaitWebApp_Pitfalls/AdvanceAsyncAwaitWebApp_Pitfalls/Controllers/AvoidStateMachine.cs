using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdvanceAsyncAwaitWebApp_Pitfalls.Controllers
{
    public class AvoidStateMachine : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// if you remove async keyword then
        /// you will see error on "return message;"
        /// stating string cannot be converted to Task<string>
        /// so if you want to remove this error 
        /// you need to add async modifier
        /// it is example of unnecessary use of async key word
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetMessageWrongWay()
        {
            var message = "Hello World";           
            return message; 
        }

        /// <summary>
        /// If you use Task.FromResult
        /// we avoided spawning unnessary state machine.
        /// </summary>
        /// <returns></returns>
        public Task<string> GetMessageRightWay()
        {
            var message = "Hello World";
            return Task.FromResult(message);
        }

        /// <summary>
        /// if do not need to return anything you can use 
        /// Task.CompletedTask
        /// </summary>
        /// <returns></returns>
        public Task DoSomeWork()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// if the content doesn't need to be manipulated in the current
        /// method then it would not be neccesary to add async await 
        /// keyword
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetDataFromInternet()
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync("some site name");
            //if you doing some manipulation on content then it is good code.
            return content;
        }

        /// <summary>
        /// See in the below method we avoid async await keyword
        /// by directly returning the result to the caller 
        /// but this will work if you are not going to manipulate
        /// the Task.Result
        /// </summary>
        public Task<string> GetDataFromInternet2()
        {
            var client = new HttpClient();
            return  client.GetStringAsync("some site name"); ;
        }

    }   
}
