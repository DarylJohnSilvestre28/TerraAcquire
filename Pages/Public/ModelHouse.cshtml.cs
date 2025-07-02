using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TerraAcquire.Contracts.ModelHouses;

namespace TerraAcquire.Web.Pages.Public
{
    public class ModelHouse : PageModel
    {
        public ModelHouseDto? House { get; set; }

        public void OnGet()
        {

            House = new ModelHouseDto
            {
                Features = "SquareFeet:3500,Bedrooms:5,Bathrooms:4,Price:97000000",
                Name = "Gemme"
            };
        }
    }
}