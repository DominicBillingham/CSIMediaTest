
using AspNetCore.Data;
using CSIMediaTest.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

            var sortedNumbers = new SortedNumbers(sortByAscending, (float)timeElapsed);
            sortedNumbers.Numbers = JsonSerializer.Serialize(numberList);

            _context.SortedNumbers.Add(sortedNumbers);
            _context.SaveChanges();

            return View("Index", sortedNumbers);

        }

        private List<int> SplitNumberString(string numberListString)
        {
            List<int> numberList = new List<int>();
            foreach (string number in numberListString.Split(" "))
            {
                int result;
                if (int.TryParse(number, out result))
                {
                    numberList.Add(int.Parse(number));
                }
                else
                {
                    ModelState.AddModelError("Incorrect Input", "This isn't a number and has been ignored: " + number);
                    continue;
                }
            }
            return numberList;
        }

        public FileContentResult DownloadSortedList(int listId)
        {
            var SortedNumber = _context.SortedNumbers.Find(listId);
            string jsonString = JsonSerializer.Serialize(SortedNumber);
            var fileBytes = Encoding.ASCII.GetBytes(jsonString);

            return new FileContentResult(fileBytes, "text/plain")
            {
                FileDownloadName = "SortedNumbersJSON"
            };
        }

    }
}