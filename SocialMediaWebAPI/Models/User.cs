using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaWebAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is a required field.")]
        [MaxLength(60, ErrorMessage = "First Name cannot exceed 60 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is a required field.")]
        [MaxLength(60, ErrorMessage = "Last Name cannot exceed 60 characters")]
        public string LastName { get; set; }
    }
}
