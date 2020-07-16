using System.ComponentModel.DataAnnotations;

namespace UnderSea.BLL.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string CountryName { get; set; }
    }
}
