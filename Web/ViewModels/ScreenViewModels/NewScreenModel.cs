using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.ScreenViewModels
{
    public class NewScreenModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int SiteId { get; set; }
    }
}
