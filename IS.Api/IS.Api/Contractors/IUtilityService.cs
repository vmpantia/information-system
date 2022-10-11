using IS.Api.Models;

namespace IS.Api.Contractors
{
    public interface IUtilityService
    {
        Task ValidateDepartment(DepartmentRequestModel model);
    }
}