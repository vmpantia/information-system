using IS.Web.Contractors;
using IS.Web.DataAccess;
using IS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IS.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDepartmentService _department;
        private readonly IRequestService _request;
        public DashboardController(IDepartmentService department,
                                   IRequestService request)
        {
            _department = department;
            _request = request;
        }

        public async Task<IActionResult> Index() 
        {
            var model = new DashboardViewModel
            {
               RequestCount = await _request.GetCountAsync(),
               RequestLast = Constants.NA,

               DepartmentCount = await _department.GetCountAsync(),
               DepartmentLast = Constants.NA
            };

            return View(model);
        }
    }
}
