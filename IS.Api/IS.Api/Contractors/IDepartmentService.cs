using IS.Api.DataAccess;
using IS.Api.Models;

namespace IS.Api.Contractors
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department_MST>> GetDepartmentListAsync(FilterSetting setting);
        Task<int> GetDepartmentsCountAsync();
        Task<Department_MST> GetDepartmentByIDAsync(Guid internalID);
        Task SaveDepartmentAsync(DepartmentRequestModel model);
    }
}