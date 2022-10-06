using IS.Web.Contractors;
using IS.Web.DataAccess;
using IS.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IS.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRequestService _request;
        private readonly ISDbContext _db;
        public DepartmentService(IRequestService request, ISDbContext dbContext)
        {
            _request = request;
            _db = dbContext;
        }

        public async Task<IEnumerable<Department_MST>> GetAllByFilterAsync(FilterSetting setting)
        {
            return await _db.Department_MST.ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _db.Department_MST.Where(data => data.Status.Equals(Constants.STATUS_ENABLED))
                                           .CountAsync();
        }

        public async Task<Department_MST> FindOneAsync(Guid internalID)
        {
            var result = await _db.Department_MST.FindAsync(internalID);

            if (result == null)
                throw new Exception(Constants.ERROR_DATA_NOT_FOUND);

            return result;
        }

        public async Task SaveAsync(DepartmentViewModel model, ClientInformation clientInfo)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    //Insert Request
                    var request = await _request.InsertAsync(_db, 
                                                             clientInfo.UserID, 
                                                             model.FunctionID, 
                                                             Constants.REQUEST_STATUS_COMPLETED);

                    switch (model.FunctionID)
                    {
                        case Constants.FUNCTIONID_DEPARTMENT_ADD_ADMIN:
                            //Set New Guid and Created Date
                            model.InternalID = Guid.NewGuid();
                            model.CreatedDate = Globals.EXEC_DATE;
                            await InsertAsync(model);
                            break;
                        case Constants.FUNCTIONID_DEPARTMENT_CHANGE_ADMIN:
                            //Set Modified Date
                            model.ModifiedDate = Globals.EXEC_DATE;
                            await UpdateAsync(model);
                            break;
                    }

                    //Insert Transaction
                    await InsertTransactionAsync(model, request.RequestID);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }

        private async Task InsertAsync(DepartmentViewModel model)
        {
            var newDepartment = new Department_MST
            {
                InternalID = model.InternalID,
                Name = model.Name,
                Manager_InternalID = model.Manager_InternalID,
                Status = model.Status,
                CreatedDate = model.CreatedDate,
                ModifiedDate = null,
            };
            await _db.Department_MST.AddAsync(newDepartment);
            await _db.SaveChangesAsync();
        }
        private async Task UpdateAsync(DepartmentViewModel model)
        {
            var result = await FindOneAsync(model.InternalID);
            _db.Entry(result).CurrentValues.SetValues(new
            {
                model.Name,
                model.Manager_InternalID,
                model.Status,
                model.CreatedDate,
                model.ModifiedDate
            });
            await _db.SaveChangesAsync();
        }
        private async Task InsertTransactionAsync(DepartmentViewModel model, string RequestID)
        {
            var newDepartment = new Department_TRN
            {
                RequestID = RequestID,
                InternalID = model.InternalID,
                Name = model.Name,
                Manager_InternalID = model.Manager_InternalID,
                Status = model.Status,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
            };
            await _db.Department_TRN.AddAsync(newDepartment);
            await _db.SaveChangesAsync();
        }

    }
}
