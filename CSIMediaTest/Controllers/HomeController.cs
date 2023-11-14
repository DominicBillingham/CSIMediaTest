
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

            List<int> numberArray = SplitNumberString(numberList);

            //Assumption 1: Time taken is just for the sort, rather than the full HTTP request

            Stopwatch sw = Stopwatch.StartNew();

            if (sortByAscending)
            {
                numberArray = numberArray.OrderBy(number => number).ToList();
            } else
            {
                numberArray = numberArray.OrderByDescending(number => number).ToList();
            }

            var timeElapsed = sw.Elapsed.TotalMilliseconds;

            var sortedNumbers = new SortedNumbers(sortByAscending, (int)timeElapsed);

            foreach (int number in numberArray)
            {
                sortedNumbers.Numbers.Add(new Number(number));
            }

            _context.SortedNumbers.Add(sortedNumbers);
            _context.SaveChanges();

            return Ok();

        }

        private List<int> SplitNumberString(string numberString)
        {
            List<int> numberArray = new List<int>();
            foreach (string number in numberString.Split(" "))
            {
                numberArray.Add(int.Parse(number));
            }
            return numberArray;
        }

    }
}