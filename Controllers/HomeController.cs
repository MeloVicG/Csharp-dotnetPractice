using System;
using Microsoft.AspNetCore.Mvc;

namespace HelloASP
{
    public class HomeController : Controller
    //HomeController will be called Home in View
    {
        //------------------------------------------
        //Requests
        //Localhost:5000
        //Redirects
        // public RedirectToActionResult Method()
        // {
        // // Will redirect to the "OtherMethod" method
        // return RedirectToAction("OtherMethod", new {Food = "sandwiches", Quantity = 5 });
        // }
        //-------------------------
        // In your controller class

        //-------------------------
        //this redirect is performance efficient
        [HttpGet("")]
        // public ViewResult Index()
        public IActionResult Index()
        {
            return View();
        }


        //this redirects to index
        [HttpGet("hello")]
        public IActionResult Hello()
        // public RedirectToActionResult Hello()
        // public RedirectResult Hello()
        {
            Console.WriteLine("We are Redirecting...");
            return RedirectToAction("HelloUser", new { username = "Devon", Location = "Seattle" });
                     //this goes to ViewResult Method()
//                                another way
//              var param = new{username="Devon", Location="Seattle"}
        }
        //------------------------------
        // Other code
        // public ViewResult OtherMethod()
        // {
        // return View();
        // }

        // [HttpGet]
        // [Route("other/{Food}/{Quantity}")]
        // public ViewResult OtherMethod(string Food, int Quantity)
        // {
        //     Console.WriteLine($"I ate {Quantity} {Food}.");
        //     // Writes "I ate 5 sandwiches."
        //     return View();
        // }
        //----------------------------------------  
        // [HttpGet]
        // [Route("")] //this will pair us with whatever LH:5000 is
        // [HttpGet("")] // can collapse both

        // method needs to be defined to view response
        // public string Index()
        // public ViewResult HiThere()
        // {
        // ViewResult myView = View();
        // return myView;
        //not neccessary

        //looks for file in Views folder
        // Views/Home/HiThere.cshtml
        //if it does not find it in file will look in Shared
        // return View(); //("HiThere")
        // return "hello from Controller";
        // }
        //------------
        //Localhost:5000/hello
        // [HttpGet("Index")] 
        // public ViewResult Index()
        // {
        //     return View();
        // }

        //------------
        // [HttpGet]
        // [Route("hello")] 
        // public string Hello()
        // {
        //     return "HI AGAIN JEEZ!";
        // }
        //------------
        [HttpGet("users/{username}/{location}")]
        public IActionResult HelloUser(string username, string location)
        {
            var response = new{user=username,place=location};
            if (location == "Seattle")
                // return $"Hello {username}, go Seahawks";
                return Json(response);
            else if (location =="Portland")
                return View("Index");
            return RedirectToAction("Index");
            // return $"Hello {username}, im at {location}";
        }
    }
}