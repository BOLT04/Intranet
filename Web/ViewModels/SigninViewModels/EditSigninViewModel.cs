using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.ScreenViewModels
{
    public class EditSigninViewModel
    {
        [Required]
        public int SigninId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int SiteId { get; set; }

        [Required]
        public DateTime TimeIn { get; set; }

        [Required]
        public DateTime TimeOut { get; set; }
    }
}
