using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Site
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Colour { get; set; }

        public virtual ICollection<Signin> Signins { get; private set; }

        public virtual ICollection<EmployeeSite> Employees { get; private set; }

        public virtual ICollection<Screen> Screens { get; private set; }
    }
}
