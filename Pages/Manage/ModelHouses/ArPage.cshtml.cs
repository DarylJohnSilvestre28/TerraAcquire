using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class ArPageModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public string InputMessage { get; set; }

        public void OnGet()
        {
            Message = "This is a default message!";
        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(InputMessage))
            {
                Message = InputMessage;
            }
        }
    }
}
