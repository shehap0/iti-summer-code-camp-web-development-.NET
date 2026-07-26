using Microsoft.AspNetCore.Mvc;

namespace dotNetSumMVCD01.Controllers
{
    public class TestController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //Actions (Methods):
        //1. Always Public, Can't be Private or Protected
        //2. Cant be overloaded

        //public ContentResult ShowHello()
        //{
        //    //Declare Object
        //    var msg = new ContentResult();
        //    //Set Object
        //    msg.Content = "Hello From Controller";
        //    //Return
        //    return msg;
        //}

        //Localhost:port/Test/ShowHello
        //public JsonResult ShowHello2()
        //{
        //    //Declare Object
        //    var msg = new JsonResult() { message = "Hello From Controller" };
        //    //Set Object
        //    msg.Content = "Hello From Controller";
        //    //Return
        //    return msg;
        //}

        //public string ShowHello2()
        //{
        //    var msg = "Hello From Controller";
        //    return msg;
        //}

        //public ViewResult ShowHello3()
        //{
        //    var msg = new ViewResult();
        //    msg.ViewName = "ShowHello3";
        //    return msg;
        //    //return View("ShowHello3");
        //}

        //public ViewResult ShowHello3()
        //{
        //    return View();
        //}

        //public IActionResult ShowHello4(int id)
        //{
        //    if (id%2 == 0) // even
        //    {
        //        //Declare Object
        //        var msg = new ContentResult();
        //        //Set Object
        //        msg.Content = "Hello From Controller";
        //        //Return
        //        return msg;
        //    }
        //    else
        //    {
        //        var msg = new ViewResult();
        //        msg.ViewName = "ShowHello3";
        //        return msg;
        //    }
        //}

        //public IActionResult ShowHello3()
        //{
        //    return View();
        //}
    }
}
