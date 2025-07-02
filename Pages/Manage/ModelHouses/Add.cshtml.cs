using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public string ItemName { get; set; }

        [BindProperty]
        public string ItemDescription { get; set; }

        // Simulated data storage (You could replace this with a database or other data source)
        public static List<Item> Items = new List<Item>();

        public void OnGet()
        {
            // This will run when the page is first accessed (GET request)
        }

        public IActionResult OnPost()
        {
            // If model is valid, add the new item to the list
            if (ModelState.IsValid)
            {
                var newItem = new Item
                {
                    Name = ItemName,
                    Description = ItemDescription
                };

                Items.Add(newItem);

                // Redirect to another page (e.g., a list of items)
                return RedirectToPage("/Index");
            }

            // If model is invalid, stay on the same page and show errors
            return Page();
        }
    }

    // Item class representing an item being added
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}   