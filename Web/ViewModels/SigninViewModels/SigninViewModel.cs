using System;

namespace Web.ViewModels.EmployeeViewModels
{
    public class SigninViewModel
    {
        public int Id { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        public int EmployeeId { get; set; }

        public int SiteId { get; set; }
    }
}
