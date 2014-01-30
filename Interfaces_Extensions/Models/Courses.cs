using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces_Extensions.Models
{
    public class Courses
    {
        [Key]
        [Display(Name = "Course Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(100, 999, ErrorMessage = "Invalid {0}, Courses must be numbered between {1} and {2}")]
        public int Id { get; set; }

        [Display(Name = "Course")]
        [StringLength(50, ErrorMessage = "Invalid {0}, {0} Must be between {2} and {1} in length", MinimumLength = 5)]
        public string CourseName { get; set; }

        [Display(Name = "Credit Hours")]
        [Required(ErrorMessage = "{0} is required for all new classes.")]
        [Range(0, 4, ErrorMessage = "The {0} has a range of {2} and {1}.")]
        public int Credits { get; set; }

        public virtual ICollection<Students> students { get; set; }
    }
}