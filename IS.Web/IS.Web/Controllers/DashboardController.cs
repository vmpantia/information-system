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
            //var request = await _request.Last<DateTime>(sort => sort.CreatedDate);
            //var department = await _department.Last<DateTime>(sort => sort.CreatedDate);

            var model = new DashboardViewModel
            {
               RequestCount = await _request.GetCountAsync(),
               //RequestLast = request == null ? Constants.NA : request.CreatedDate.ToString(),

               DepartmentCount = await _department.GetCountAsync(),
               //DepartmentLast = department == null ? Constants.NA : department.CreatedDate.ToString(),
            };

            return View(model);
        }
    }
}
