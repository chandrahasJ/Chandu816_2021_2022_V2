using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdvanceAsyncAwaitWebApp_Pitfalls.Controllers
{
    public class DoesntMatterWhichThread : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Example for we are not concern to which 
        /// thread the task result returns to
        /// ConfigureAwait(false) - implies that we are not concern that 
        ///              thread should return to the same thread.
        /// </summary>
        public async Task<string> GetDataFromInternet()
        {
            var client = new HttpClient();
            // Thread Id - 1
            var content = await client.GetStringAsync("some site name")
                                        .ConfigureAwait(false);
            // Thread Id - 23. ConfigureAwait as false
            // is useful in Web applications.
            content = content.Replace("site", "mysitename").Trim();

            // Thread Id - 23
            var content2 = await client.GetStringAsync("some site name");
            // Thread id - 23 same thread id as by default ConfigureAwait 
            // is always true. Useful in WPF, WinForms
            content2 = content2.Replace("site", "mysitename").Trim();

            return content;
        }




        public class Product
        {
            // never perform an async inside constructor
            public Product() { }
            //Alternative two - if you object will be created in only one way
            public static async Task<Product> CreateProduct()
            {
                //var getProduct = await DBContext.Products.Select();
                return new Product();
            }
        }

        // Alternative one - object needs to be created in multiple ways
        public class ProductFactory
        {
            public ProductFactory() { }   
            public  async Task<Product> CreateProduct()
            {
                //var getProduct = await DBContext.Products.Select();
                return new Product();
            }
        }



    }
}
