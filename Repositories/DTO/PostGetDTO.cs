using ModelsLibraryBlog;
using System.ComponentModel.DataAnnotations;

namespace BlogManagementAPI.Repositories.DTO
{
    public class PostGetDTO
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int UserID { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; } 

        public List<string> ImageUrls { get; set; } = null;
        public DateTime DatePosted { get; set; }
        public string DatePostedFormatted => DatePosted.ToString("yyyy-MM-dd HH:mm:ss");
        
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } 
    }
}
