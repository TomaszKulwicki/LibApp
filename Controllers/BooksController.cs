using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
       public IActionResult Random()
        {
            var firstBook = new Book() { Name = "English dictionary" };
            var secondBook = new Book() { Name = "German dictionary" };

            ViewBag.Book1 = firstBook;
            ViewData["Book2"] = secondBook;

            return View();
        }

        public IActionResult Edit(int bookid)
        {
            return Content("id = " + bookid);
        }

        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }

            return Content($"pageIndex={pageIndex}$sortBy={sortBy}");
        }
        [Route("books/released/{year:regex(^\\d{{4}}$):min(1920):max(2021)}/{month:range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
