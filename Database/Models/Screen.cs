using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Screen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string AuthCode { get; set; }

        [Required]
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }
    }
}
