
using AspNetCore.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSIMediaTest.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext applicationDbContext) { 
            _context = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sort(string numberList, bool sortByAscending)
        {

            var fish = _context.SortedLists.FirstOrDefault();

            Stopwatch sw = Stopwatch.StartNew();

            List<int> numberArray = new List<int>();
            foreach (string number in numberList.Split(" "))
            {
                numberArray.Add(int.Parse(number));
            }

            //Assumption 1: Time taken is just for the sort, rather than the full HTTP request

            if (sortByAscending)
            {
                numberArray = numberArray.OrderBy(number => number).ToList();
            } else
            {
                numberArray = numberArray.OrderByDescending(number => number).ToList();
            }

            var timeElapsed = sw.Elapsed;


            return Ok(timeElapsed.TotalMilliseconds);
        }

    }
}