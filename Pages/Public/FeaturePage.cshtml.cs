using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAcquire.Web.Pages.Public
{
    public class FeaturePageModel : PageModel
    {

        public string FeatureDescription { get; set; }


        public string UserInput { get; set; }


        public void OnGet()
        {

        }

        public void OnPost()
        {

            UserInput = Request.Form["userInput"];
        }
    }
}