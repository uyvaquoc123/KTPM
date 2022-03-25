using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Models
{
    public class Student
    {
        public Student()
        {
            Code = string.Empty;
            Name = string.Empty;
            Department = new Department();
        }


        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string? Code { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; }
        [MaxLength(512)]
        public string? Address { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
    
}