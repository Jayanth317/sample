using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.Pages
{
    public class PizzaModel : PageModel
    {
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();

        public List<Pizza> pizzas = new();

        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }

        public string GlutenFreeText(Pizza pizza)
        {
            return pizza.IsGlutenFree ? "Gluten Free" : "Not Gluten Free";
        }
        public string VeganText(Pizza pizza)
        {
            return pizza.IsVegan ? "Vegan" : "Non Vegan";
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }
    }
}
