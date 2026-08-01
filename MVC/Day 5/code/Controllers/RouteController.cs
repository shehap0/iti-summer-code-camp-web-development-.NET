using Microsoft.AspNetCore.Mvc;

namespace dotNetSumMVCD05.Controllers
{
    public class RouteController : Controller
    {
        //[HttpGet("Index/{id:int}")]
        //[Route("Route/Index/{id:int}")]
        public IActionResult Index(int id)
        {
            return Content($"ID: {id}");
        }
        //[HttpGet("Index/{name:alpha}")]
        //[Route("Route/Index/{name:alpha}")]
        //[HttpGet("Test/{name:alpha}")]
        public IActionResult Index(string name)
        {
            return Content($"Name: {name}");
        }
        public IActionResult Test(int id)
        { 
            return Content($"ID: {id}");
        }
    }
}
