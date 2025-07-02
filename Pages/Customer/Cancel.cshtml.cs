using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAcquire.Web.Pages.Customer
{
    public class CancelModel : PageModel
    {
        public string Message { get; set; }

        
        public DateTime AccessTime { get; set; }

        public void OnGet()
        {
          
            AccessTime = DateTime.Now;

            
            bool isSpecialCondition = true; 

            if (isSpecialCondition)
            {
                Message = "This is a special cancellation message!";
            }
            else
            {
                Message = "You have accessed the cancel page.";
            }
        }
    }
}
