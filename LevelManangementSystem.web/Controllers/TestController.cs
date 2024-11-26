using LevelManangementSystem.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LevelManangementSystem.web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {

            var data = new TestViewModel
            {
                Name = "lucas Liu",
            };

            return View(data);
        }
    }
}
