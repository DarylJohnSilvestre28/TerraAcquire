using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAcquire.Web.Pages.Manage.Trippings
{
    public class CancelModel : PageModel
    {
        public IActionResult OnGet()
        {
            // You can put any initialization logic here
            return Page();
        }

        public IActionResult OnPost()
        {
            // Logic to handle the cancel action
            // For now, we can just redirect to another page
            return RedirectToPage("/Index");
        }
    }
}