using System;
using System.ComponentModel.DataAnnotations;

namespace Test
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }
}
