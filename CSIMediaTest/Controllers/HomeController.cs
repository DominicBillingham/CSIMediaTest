
using AspNetCore.Data;
using CSIMediaTest.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

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

        public IActionResult Sort(string numberListString, bool sortByAscending)
        {

            List<int> numberList = SplitNumberString(numberListString);

            //Assumption 1: Time taken is just for the sort, rather than the full HTTP request

            Stopwatch sw = Stopwatch.StartNew();

            if (sortByAscending)
            {
                numberList = numberList.OrderBy(number => number).ToList();
            } else
            {
                numberList = numberList.OrderByDescending(number => number).ToList();
            }

            var timeElapsed = sw.Elapsed.TotalMilliseconds;

            var sortedNumbers = new SortedNumbers(sortByAscending, (int)timeElapsed);

            foreach (int number in numberList)
            {
                sortedNumbers.Numbers.Add(new Number(number));
            }

            _context.SortedNumbers.Add(sortedNumbers);
            _context.SaveChanges();

            return View("Index", sortedNumbers);

        }

        private List<int> SplitNumberString(string numberListString)
        {
            List<int> numberList = new List<int>();
            foreach (string number in numberListString.Split(" "))
            {
                numberList.Add(int.Parse(number));
            }
            return numberList;
        }

        public FileContentResult DownloadSortedList(int listId)
        {
            var SortedNumber = _context.SortedNumbers.Where(x => x.Id == listId).Include(x => x.Numbers);
            string jsonString = JsonSerializer.Serialize(SortedNumber);
            var fileBytes = Encoding.ASCII.GetBytes(jsonString);

            return new FileContentResult(fileBytes, "text/plain")
            {
                FileDownloadName = "SortedNumbersJSON"
            };
        }

    }
}