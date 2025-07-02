using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace   TerraAcquire.Pages.Users
{
    public class Invite
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
        public DateTime DateSent { get; set; } = DateTime.Now;
        public bool IsAccepted { get; set; } = false;
    }
}