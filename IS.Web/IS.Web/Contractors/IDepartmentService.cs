using IS.Web.DataAccess;
using IS.Web.Models;

namespace IS.Web.Contractors
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department_MST>> GetAllByFilterAsync(FilterSetting setting);
        Task<int> GetCountAsync();
        Task<Department_MST> FindOneAsync(Guid internalID);
        Task SaveAsync(DepartmentViewModel model, ClientInformation clientInfo);
    }
}