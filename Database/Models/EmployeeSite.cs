namespace Database.Models
{
    public class EmployeeSite
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int SiteId { get; set; }
        public virtual Site Site { get; set; }
    }
}
