using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Rank
    {
        public Rank()
        {
            Name = string.Empty;
            Students  = new List<Student>();
        }

        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}