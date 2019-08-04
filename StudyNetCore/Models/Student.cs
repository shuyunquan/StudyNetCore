using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyNetCore.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [StringLength(20)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
    }
}
