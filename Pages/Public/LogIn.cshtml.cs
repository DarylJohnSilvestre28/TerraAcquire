using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAcquire.Web.Pages.Public
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
         
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Both fields are required.";
                return Page();
            }

            
            if (Username == "admin" && Password == "password123") 
            {
               
                return RedirectToPage("/Home");
            }
            else
            {
                
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}