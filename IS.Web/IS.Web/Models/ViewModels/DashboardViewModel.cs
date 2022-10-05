using IS.Web.DataAccess;

namespace IS.Web.Models
{
    public class DashboardViewModel
    {
        public int RequestCount { get; set; }
        public int EmployeeCount { get; set; }
        public int DepartmentCount { get; set; }
        public int PositionCount { get; set; }
        public string RequestLast { get; set; }
        public string EmployeeLast { get; set; }
        public string DepartmentLast { get; set; }
        public string PositionLast { get; set; }
    }
}
