using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CA3_TATJ_V2.Models
{
    public class Post
    {
        [Required]
        public int postId { get; set; }

        [Required]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please enter post title")]
        [StringLength(50, ErrorMessage = "The name must be less than {1} characters.")]
        [Display(Name = "Post Title")]
        public string postHeader { get; set; }

        [Required(ErrorMessage = "Please enter post content")]
        [Display(Name = "Post Content")]
        public string postContent { get; set; }

        [Required]
        public string postDate { get; set; }

    }
}
