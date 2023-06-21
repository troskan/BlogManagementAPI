using ModelsLibraryBlog;
using System.ComponentModel.DataAnnotations;

namespace BlogManagementAPI.Repositories.DTO
{
    public class PostEditDTO
    {
        [MinLength(1), MaxLength(50)]
        [Required]
        
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int UserID { get; set; }

        public List<string> ImageUrls { get; set; } = null;
        public string? YoutubeUrl { get; set; } = null;

        [Required]
        public int CategoryID { get; set; }
    }
}
