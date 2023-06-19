using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibraryBlog
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public int RoleID { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(5), MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public DateTime DateRegistered { get; set; }
    }
}
