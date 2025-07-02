using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TerraAcquire.Web.Pages.Public
{
    public class CustomerSignUpModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }

        public bool IsSubmitted { get; set; }

        public string FullNameError { get; set; }
        public string EmailError { get; set; }
        public string DateOfBirthError { get; set; }
        public string PhoneNumberError { get; set; }

        public void OnGet()
        {
            Customer = new Customer ();
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
               
                IsSubmitted = true;

               
                FullNameError = null;
                EmailError = null;
                DateOfBirthError = null;
                PhoneNumberError = null;
            }
            else
            {
             
                FullNameError = "Please enter a valid name.";
                EmailError = "Please enter a valid email.";
                DateOfBirthError = "Please select a valid date of birth.";
                PhoneNumberError = "Please enter a valid phone number.";
            }
        }
    }

    public class Customer
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}