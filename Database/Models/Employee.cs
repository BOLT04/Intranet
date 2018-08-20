using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }
        
        [Required]
        public virtual ICollection<EmployeeSite> EmployeeSites { get; set; }

        public virtual ICollection<Clockin> Clockins { get; set; }
    }
}
