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
                throw new DepartmentException("Department cannot be NULL");

            //Check if Department Name is Empty
            if (string.IsNullOrEmpty(model.department.Name))
                throw new DepartmentException("Department Name is Required");

            //Check if Department Name Length is more than 50 characters
            if (model.department.Name.Length == 50)
                throw new DepartmentException("Department Name length is more than 50 characters");

            //Check if Department Name Exist
            var isExist = await IsDepartmentExist(model);
            if (isExist)
                throw new Exception("Department is already exist");

            //Check if Department Manger is Empty
            if (model.department.Manager_InternalID == Guid.Empty)
                throw new DepartmentException("Department Manager is Required");
        }

        private async Task<bool> IsDepartmentExist(DepartmentRequestModel model)
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
    }
}
