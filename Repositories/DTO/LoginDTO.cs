using System.ComponentModel.DataAnnotations;

namespace BlogManagementAPI.Repositories.DTO
{
    public class LoginDTO
    {
        [MinLength(3), MaxLength(50)]
        public string UserName { get; set; }
        [MinLength(6), MaxLength(100)]
        public string Password { get; set; }
    }
}
