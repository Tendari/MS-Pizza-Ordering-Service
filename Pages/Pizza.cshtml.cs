using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
      
        using RazorPagesPizza.Models;
        using RazorPagesPizza.Services;
        public List<Pizza> pizzas = new();
    public string GlutenFreeText(Pizza pizza)
    {
        if (pizza.IsGlutenFree)
            return "Gluten Free";
        return "Not Gluten Free";
    }
    public void OnGet()
        {
            pizzas = PizzaService.GetAll();
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
    [BindProperty]
    public Pizza NewPizza { get; set; } = new();
    public IActionResult OnPostDelete(int id)
    {
        PizzaService.Delete(id);
        return RedirectToAction("Get");
    }
}
}
