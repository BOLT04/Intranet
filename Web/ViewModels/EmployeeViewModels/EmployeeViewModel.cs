using System.Collections.Generic;

namespace Web.ViewModels.EmployeeViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string FullName
        {
            get { return FirstName + " " + Surname; }
        }

        public ICollection<EmployeeSiteViewModel> Sites { get; set; }

        public ICollection<EmployeeSigninViewModel> Signins { get; set; }
    }
}
