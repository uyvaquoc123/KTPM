using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Models
{
    public class Student
    {
    
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string? Code { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; }
        [MaxLength(512)]
        public string? Address { get; set; }
        public int Age { get; set; }
    }
    
}