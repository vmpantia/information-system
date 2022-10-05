using IS.Web.Contractors;
using IS.Web.DataAccess;
using IS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IS.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _department;
        public DepartmentController(IDepartmentService department)
        {
            _department = department;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new DepartmentListViewModel
            {
                departments = await _department.GetAllByFilterAsync(new FilterSetting())
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = UtilityController.GetDepartmentViewModel(Constants.FUNCTIONID_DEPARTMENT_ADD_ADMIN);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var department = await _department.FindOneAsync(id);
            var model = UtilityController.GetDepartmentViewModel(Constants.FUNCTIONID_DEPARTMENT_CHANGE_ADMIN, department);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(DepartmentViewModel model)
        {
            var clientInfo = new ClientInformation();
            var isCreate = model.FunctionID.Contains("A");
            try
            {
                if (!ModelState.IsValid)
                    return View((isCreate ? Constants.VIEW_DEPARTMENT_CREATE : Constants.VIEW_DEPARTMENT_EDIT), model);

                await _department.SaveAsync(model, clientInfo);
            }
            catch (Exception ex)
            {
                var error = new ErrorViewModel
                {
                    Title = "Error in Saving Department",
                    ErrorMessage = ex.Message
                };
                return View(error);
            }
            return RedirectToAction(Constants.VIEW_DEPARTMENT_INDEX);
        }

        
    }
}
