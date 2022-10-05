using IS.Web.DataAccess;

namespace IS.Web.Models
{
    public class DepartmentListViewModel
    {
        public IEnumerable<Department> departments { get; set; }
    }
}
