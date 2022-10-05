using IS.Web.DataAccess;

namespace IS.Web.Models
{
    public class DepartmentListViewModel
    {
        public IEnumerable<Department_MST> departments { get; set; }
    }
}
