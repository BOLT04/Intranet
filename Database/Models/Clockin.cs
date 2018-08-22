using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Clockin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public int SiteId { get; set; }

        public Site Site { get; set; }
    }
}
