using IS.Api.Exceptions;
using IS.Api.DataAccess;
using IS.Api.Models;
using IS.Api.Contractors;
using Microsoft.EntityFrameworkCore;

namespace IS.Api.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly ISDbContext _db;
        public UtilityService(ISDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task ValidateDepartment(DepartmentRequestModel model)
        {
            if (model == null)
                throw new DepartmentException(Constants.ERROR_DEPARTMENT_NULL);


            if (model.FunctionID == Constants.FUNCTIONID_DEPARTMENT_CHANGE_ADMIN)
            {
                var isChanged = await IsDepartmentChangeAsync(model);
                if (!isChanged)
                    throw new DepartmentException(Constants.ERROR_DEPARTMENT_NO_CHANGES);
            }

            //Check if Department Name is Empty
            if (string.IsNullOrEmpty(model.department.Name))
                throw new DepartmentException(Constants.ERROR_DEPARTMENT_NAME_REQUIRED);

            //Check if Department Name Length is more than 50 characters
            if (model.department.Name.Length == 50)
                throw new DepartmentException(Constants.ERROR_DEPARTMENT_NAME_LENGTH);

            //Check if Department Name Exist
            var isExist = await IsDepartmentNameExistAsync(model);
            if (isExist)
                throw new Exception(Constants.ERROR_DEPARTMENT_EXIST);

            //Check if Department Manger is Empty
            if (model.department.Manager_InternalID == Guid.Empty)
                throw new DepartmentException(Constants.ERROR_DEPARTMENT_MANAGER_REQUIRED);
        }

        private async Task<bool> IsDepartmentNameExistAsync(DepartmentRequestModel model)
        {
            var result = await _db.Department_MST.Where(data => data.Name == model.department.Name)
                                                 .ToListAsync();
            if (result == null || result.Count == 0)
                return false;

            //If functionID is Changed
            if (model.FunctionID == Constants.FUNCTIONID_DEPARTMENT_CHANGE_ADMIN)
            {
                //Get Old Department then compare Department Name if changed
                var oldDepartment = await _db.Department_MST.FindAsync(model.department.InternalID);
                if (oldDepartment == null || oldDepartment.Name == model.department.Name)
                    return false;
            }
            return true;
        }

        private async Task<bool> IsDepartmentChangeAsync(DepartmentRequestModel model)
        {
            var result = await _db.Department_MST.FindAsync(model.department.InternalID);

            if (result == null)
                return false;

            return model.department.Name != result.Name ||
                   model.department.Manager_InternalID != result.Manager_InternalID;
        }
    }
}
