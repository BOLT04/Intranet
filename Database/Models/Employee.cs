using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Employee
    {
        ICollection<Signin> _signins;
        ICollection<EmployeeSite> _sites;

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }
        
        public string FullName {
            get { return FirstName + " " + Surname; }
       }

        [Required]
        public virtual ICollection<EmployeeSite> Sites 
        { 
            get { return _sites; } 
            private set { _sites = value; } 
        }

        public virtual ICollection<Signin> Signins 
        { 
            get { return _signins; } 
            private set { _signins = value; } 
        }
    }
}
