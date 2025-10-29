using System.ComponentModel.DataAnnotations;

namespace CookieBasedAuthenticationDemo.Models
{
    public class Registration
    {
        [Required(ErrorMessage ="Name is compulsory")]
        public string Name { get; set; }
        [Range(18,60)]
        public int Age { get; set; }
        [EmailAddress(ErrorMessage="Email id not valid")]
        public string Email { get; set; }

       [Required(ErrorMessage ="Required Password")]
        [MinLength(8)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        public string MobileNo { get; set; }

        [CreditCard(ErrorMessage ="Invalid card no")]
        public long CreditCardNo { get; set; }
    }
}
