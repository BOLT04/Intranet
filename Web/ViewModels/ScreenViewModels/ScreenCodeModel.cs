using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.ScreenViewModels
{
    public class ScreenCodeModel
    {
        [Required]
        public string code { get; set; }
    }
}
