using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces_Extensions.Models
{
    public class Students
    {
        [Key]
        [Display(Name = "Student ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(10000, 32000, ErrorMessage = "Invalid {0}. Must be between {2} and {1} digits in length.")]
        public Int16 Id { get; set; }

        [Display(Name = "Student Name")]
        [StringLength(100, ErrorMessage = "Invalid length for {0}. Must be between {2} and {1} characters.", MinimumLength = 10)]
        public string Name { get; set; }

        public virtual ICollection<Courses> courses { get; set; }
    }
}