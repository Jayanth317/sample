using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.Pages
{
    public class BurgerModel : PageModel
    {
        [BindProperty]
        public Burger NewBurger { get; set; } = new();

        public List<Burger> burgers = new();

        public void OnGet()
        {
            burgers = BurgerService.GetAll();
        }

        public string GlutenFreeText(Burger burger)
        {
            return burger.IsGlutenFree ? "Gluten Free" : "Not Gluten Free";
        }
        public string VeganText(Burger burger)
        {
            return burger.IsVegan ? "Vegan" : "Non Vegan";
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            BurgerService.Add(NewBurger);
            return RedirectToAction("Get");
        }
    }
}
