using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ScreenCodeModel
    {
        [Required]
        public string code { get; set; }
    }
}
