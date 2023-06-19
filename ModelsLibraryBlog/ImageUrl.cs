using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsLibraryBlog
{
    public class ImageUrl
    {
        [Key]
        public int ImageUrlID { get; set; }
        [Required, Url, StringLength(5000)]
        public string Url { get; set; }
        public int PostID { get; set; }
        [JsonIgnore]
        public Post Post { get; set; }
    }
}
