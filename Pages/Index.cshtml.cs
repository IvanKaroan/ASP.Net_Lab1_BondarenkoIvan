using Lab2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(DishOfTheWeekRepositary repositary)
        {
            _repositary = repositary;
        }
        public readonly DishOfTheWeekRepositary _repositary;

        public void OnGet()
        {

        }

        public IActionResult OnPostCreate(string NameDish, string DayOfWeek, string ServingTime, string TipeDish, decimal Price)
        {
            _repositary.Add(new DishOfTheWeek(NameDish, DayOfWeek, ServingTime, TipeDish, Price));
            return RedirectToPage("Index");
        }

        public IActionResult OnPostRemove(Guid id)
        {
            _repositary.Remove(id);
            return RedirectToPage("Index");
        }

    }
}
