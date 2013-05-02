using System.ComponentModel.DataAnnotations;

namespace PirateThis.Domain.Entities
{
    public class CustomerDetails
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your bitcoin address")]
        public string Bitcoin { get; set; }
    }
}
