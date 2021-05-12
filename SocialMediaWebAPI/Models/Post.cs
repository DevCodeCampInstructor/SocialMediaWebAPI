using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaWebAPI.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Title is a required field.")]
        [MaxLength(60, ErrorMessage ="Title cannot exceed 60 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is a required field.")]
        [MaxLength(500, ErrorMessage = "Content cannot exceed 500 characters")]
        public string Content { get; set; }
        public int Likes { get; set; }
        public DateTime PostDate { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
