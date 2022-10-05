using IS.Web.Contractor;
using IS.Web.DataAccess;
using IS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IS.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IBaseRepository<Request> _request;
        private readonly IBaseRepository<Department> _department;
        private readonly IBaseRepository<Position> _position;
        public DashboardController(IBaseRepository<Request> requestRepository,
                                   IBaseRepository<Department> departmentRepository,
                                   IBaseRepository<Position> positionRepository)
        {
            _request = requestRepository;
            _department = departmentRepository;
            _position = positionRepository;
        }

        public async Task<IActionResult> Index() 
        {
            var request = await _request.Last<DateTime>(sort => sort.CreatedDate);
            var department = await _department.Last<DateTime>(sort => sort.CreatedDate);
            var position = await _position.Last<DateTime>(sort => sort.CreatedDate);

            var model = new DashboardViewModel
            {
               RequestCount = await _request.Count(),
               RequestLast = request == null ? Constants.NA : request.CreatedDate.ToString(),

               DepartmentCount = await _department.Count(model => model.Status == Constants.STATUS_ENABLED),
               DepartmentLast = department == null ? Constants.NA : department.CreatedDate.ToString(),

               PositionCount = await _position.Count(model => model.Status == Constants.STATUS_ENABLED),
               PositionLast = position == null ? Constants.NA : position.CreatedDate.ToString()
            };

            return View(model);
        }
    }
}
