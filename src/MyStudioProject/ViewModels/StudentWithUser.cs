using MyStudioProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudioProject.ViewModels
{
    public class StudentWithUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Hour { get; set; }
        [Required]
        public string Room { get; set; }
        public Rhythm Rhythm { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; } 
    }
}
