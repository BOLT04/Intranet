using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.ScreenViewModels
{
    public class NewSigninViewModel
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int SiteId { get; set; }
    }
}
