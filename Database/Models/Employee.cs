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
        
        public string FullName => FirstName + " " + Surname;

        [Required]
        public virtual ICollection<EmployeeSite> Sites { get; private set; }

        public virtual ICollection<Signin> Signins { get; private set; }
    }
}
