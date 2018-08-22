using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Site
    {

        ICollection<Clockin> clockins = new List<Clockin>();
        ICollection<EmployeeSite> employeeSites = new List<EmployeeSite>();
        ICollection<Screen> screens = new List<Screen>();
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Colour { get; set; }

        public virtual ICollection<Clockin> Clockins 
        { 
            get {return clockins;} 
            private set {clockins = value;} 
        }
        public virtual ICollection<EmployeeSite> EmployeesSites 
        { 
            get{return employeeSites;} 
            private set {employeeSites = value;} 
        }
        public virtual ICollection<Screen> Screens 
        { 
            get {return screens;}
            private set {screens = value;} 
        }
    }
}
