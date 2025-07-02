using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TerraAcquire.Web.Pages.Customer
{
    public class BookATripModel : PageModel
    {
        [BindProperty]
        public TripBooking Trip { get; set; }

        public List<SelectListItem> DestinationList { get; set; }

        public BookATripModel()
        {
            DestinationList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Camella", Value = "Camella" },
                new SelectListItem { Text = "Lincoln heights", Value = "Lincoln heights" },
                new SelectListItem { Text = "Lincoln heights", Value = "Lincoln heights" },
                new SelectListItem { Text = "Beverly heights", Value = "Beverly heights" },
                new SelectListItem { Text = "Lumina homes", Value = "Lumina homes" }
            };
        }

        public void OnGet()
        {
            
            Trip = new TripBooking();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                
                TempData["SuccessMessage"] = "Your trip has been booked successfully!";
                return RedirectToPage("Confirmation"); 
            }
            return Page();
        }
    }

    public class TripBooking
    {
        [Required]
        [Display(Name = "Destination")]
        public string Destination { get; set; }

        [Required]
        [Display(Name = "Departure Date")]
        public DateTime? DepartureDate { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter at least one guest.")]
        [Display(Name = "Number of Guests")]
        public int? NumberOfGuests { get; set; }
    }
}
