using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Employee
    {
        ICollection<Clockin> clockins = new List<Clockin>();
        ICollection<EmployeeSite> employeeSites = new List<EmployeeSite>();
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }
        
        [Required]
        public virtual ICollection<EmployeeSite> EmployeesSites 
        { 
            get{return employeeSites;} 
            private set {employeeSites = value;} 
        }
        public virtual ICollection<Clockin> Clockins 
        { 
            get {return clockins;} 
            private set {clockins = value;} 
        }
    }
}
