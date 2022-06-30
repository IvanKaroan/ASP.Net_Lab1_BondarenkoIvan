using Lab2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages
{
    public class UpdateModel : PageModel
    {
        public UpdateModel(DishOfTheWeekRepositary repositary)
        {
            _repositary = repositary;
        }
        public readonly DishOfTheWeekRepositary _repositary;
        public DishOfTheWeek? UpdatedDish { get; private set; }
        public void OnGet(Guid id)
        {
            UpdatedDish = _repositary.List().FirstOrDefault(x => x.Id == id) ?? new DishOfTheWeek();
        }
        public IActionResult OnPost(DishOfTheWeek Dish)
        {
            _repositary.Update(Dish);
            return RedirectToPage("Index");
        }
    }
}
