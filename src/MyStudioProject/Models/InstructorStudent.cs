using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudioProject.Models
{
    public class InstructorStudent
    {
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public ApplicationUser Instructor { get; set; }
        public string InstructorId { get; set; } 
    }
}
