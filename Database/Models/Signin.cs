using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Signin
    {
        public Signin()
        {
            TimeIn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [Required]
        public int SiteId { get; set; }

        public virtual Site Site { get; set; }
    }
}
