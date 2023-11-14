
using AspNetCore.Data;
using CSIMediaTest.Data.Models;
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

            var fish = new SortedNumbers();

            fish.TimeTakenToSort = 100;
            fish.InAscendingOrder = sortByAscending;

            fish.Numbers = new List<Number>();

            fish.Numbers.Add(new Number(5));
            fish.Numbers.Add(new Number(12));
            fish.Numbers.Add(new Number(2));

            _context.SortedNumbers.Add(fish);
            _context.SaveChanges();



            return Ok(timeElapsed.TotalMilliseconds);
        }

    }
}