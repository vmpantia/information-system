 using IS.Web.Contractor;
using IS.Web.DataAccess;
using IS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IS.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IBaseRepository<Department> _department;
        private readonly IBaseRepository<Department_TRN> _transaction;
        private readonly IBaseRepository<Request> _request;
        public DepartmentController(IBaseRepository<Department> departmentRepository,
                                    IBaseRepository<Department_TRN> transactionRepository,
                                    IBaseRepository<Request> requestRepository)
        {
            _department = departmentRepository;
            _transaction = transactionRepository;
            _request = requestRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new DepartmentListViewModel
            {
                departments = await _department.GetAll()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var model = new DepartmentViewModel
            {
                newDepartment = await _department.Find(id),
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new DepartmentViewModel
            {
                FunctionID = Constants.FUNCTIONID_DEPARTMENT_ADD_ADMIN,
                newDepartment = new Department()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var currentDepartment = await _department.Find(id);
            var model = new DepartmentViewModel
            { 
                FunctionID = Constants.FUNCTIONID_DEPARTMENT_CHANGE_ADMIN,
                newDepartment = currentDepartment
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DepartmentViewModel model)
        {
            var isCreate = model.FunctionID.Contains("A");
            
            if (!ModelState.IsValid)
                return View((isCreate ? Constants.VIEW_DEPARTMENT_CREATE : Constants.VIEW_DEPARTMENT_EDIT), model);

            var db = _department.Database;
            using (var transaction = await db.BeginTransactionAsync())
            {
                try
                {
                    await SaveAsync(model);
                    await transaction.CommitAsync();
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

            return RedirectToAction(Constants.VIEW_DEPARTMENT_INDEX);
        }

        private async Task SaveAsync(DepartmentViewModel model)
        {

            var clientInfo = new ClientInformation(); /*Get this from Session*/

            //Generate Request
            var req = await UtilityController.GenerateNewRequest(_request,
                                                                 clientInfo.UserID,
                                                                 model.FunctionID,
                                                                 "A2");
            switch (model.FunctionID)
            {
                case Constants.FUNCTIONID_DEPARTMENT_ADD_ADMIN:
                    //Set New Guid and Created Date
                    model.newDepartment.InternalID = Guid.NewGuid();
                    model.newDepartment.CreatedDate = DateTime.Now;
                    await _department.Insert(model.newDepartment);
                    break;
                case Constants.FUNCTIONID_DEPARTMENT_CHANGE_ADMIN:
                    //Set Modified Date
                    model.newDepartment.ModifiedDate = DateTime.Now;
                    await _department.Update(model.newDepartment.InternalID, 
                                             new { model.newDepartment.Name, 
                                                   model.newDepartment.Manager_InternalID,
                                                   model.newDepartment.ModifiedDate });
                    break;
            }
            //Insert Request & Transaction
            var trn = model.GetDepartment_TRN(req.RequestID);
            await _transaction.Insert(trn);
            await _request.Insert(req);
        }
    }
}
