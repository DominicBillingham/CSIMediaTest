using CSIMediaTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace CSIMediaTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sort(string numberList, bool sortByAscending)
        {

            List<int> numberArray = new List<int>();
            foreach (string number in numberList.Split(" "))
            {
                numberArray.Add(int.Parse(number));
            }

            if (sortByAscending)
            {
                numberArray = numberArray.OrderBy(number => number).ToList();
            } else
            {
                numberArray = numberArray.OrderByDescending(number => number).ToList();
            }

            return Ok(numberArray);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}