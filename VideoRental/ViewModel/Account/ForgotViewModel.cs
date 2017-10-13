using System.ComponentModel.DataAnnotations;

namespace VideoRental.ViewModel.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
