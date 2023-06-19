using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibraryBlog
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        [MinLength(1), MaxLength(50)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public int UserID { get; set; }
        public List<ImageUrl> ImageUrls { get; set; } = null;
        [Required]
        public DateTime DatePosted { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string? YoutubeUrl { get; set; } = null;
    }
}
