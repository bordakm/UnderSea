using System.ComponentModel.DataAnnotations;

namespace UnderSea.BLL.DTO
{
    public class RegisterDTO
    {

        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        [Required]
        public string CountryName { get; set; }
    }
}
