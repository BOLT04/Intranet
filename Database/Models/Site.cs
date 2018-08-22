using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Site
    {
        ICollection<Signin> _signins;
        ICollection<EmployeeSite> _employees;
        ICollection<Screen> _screens;

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Colour { get; set; }

        public virtual ICollection<Signin> Signins 
        { 
            get {return _signins;} 
            private set {_signins = value;} 
        }

        public virtual ICollection<EmployeeSite> Employees 
        { 
            get{return _employees; } 
            private set { _employees = value;} 
        }

        public virtual ICollection<Screen> Screens 
        { 
            get {return _screens;}
            private set {_screens = value;} 
        }
    }
}
