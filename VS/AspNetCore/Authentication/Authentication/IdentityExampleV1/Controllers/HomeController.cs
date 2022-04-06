using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityExampleV1.Controllers
{
    public class HomeController : Controller
    {        

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        // Authorized Persons only can
        // access the SecretPage
        public IActionResult SecretPage()
        {            
            return View();
        }

        //Anyone can get access to NormalPage
        public IActionResult NormalPage()
        {
            return View();
        }

        public IActionResult Authentication()
        {
            // Claims List of key value pair 
            var driverClaims = new List<Claim>()
            {
                new Claim("Name","Chandu"),
                new Claim("BirthDate", "07-07-1988"),
                new Claim("License No,","BBHHQWE")
            };

            // Identity created using the driver claims 
            var driverIdentity = new ClaimsIdentity(driverClaims, "Driver Identity");

            // Created the user object using driver identity
            var driver = new ClaimsPrincipal(new[] { driverIdentity });

            // This will create auth cookie
            HttpContext.SignInAsync(driver);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult UnAuthorize()
        {
            return View();
        }
    }
}
