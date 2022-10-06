using IS.Web.DataAccess;
using IS.Web.Models;

namespace IS.Web.Contractors
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department_MST>> GetDepartmentListAsync(FilterSetting setting);
        Task<int> GetDepartmentsCountAsync();
        Task<Department_MST> GetDepartmentByIDAsync(Guid internalID);
        Task SaveDepartmentAsync(DepartmentRequestModel model);
    }
}