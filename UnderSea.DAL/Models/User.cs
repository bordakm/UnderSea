using Microsoft.AspNetCore.Identity;

namespace UnderSea.DAL.Models
{
    public class User : IdentityUser<int>
    {
        public Country Country { get; set; }
        public int Place { get; set; }
        public int Score { get; set; }
    }
}
