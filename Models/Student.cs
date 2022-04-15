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
            Class = string.Empty;
            Name = string.Empty;
        }


        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string? Class { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; }
        [MaxLength(512)]
        public string? Address { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }
        public int RankId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Rank Rank { get; set; }
    }
    
}