using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibraryBlog
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [Required]
        [MaxLength(500), MinLength(1)]
        public string UserComment { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public DateTime DateCommented { get; set; }
    }
}
