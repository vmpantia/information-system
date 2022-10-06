using IS.Web.Contractors;
using IS.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _department;
        public DepartmentController(IDepartmentService department)
        {
            _department = department;
        }

        [HttpPost("GetDepartmentList")]
        public async Task<JsonResult> GetDepartmentListAsync(FilterSetting settings)
        {
            var result = await _department.GetDepartmentListAsync(settings);
            return new JsonResult(result);
        }

        [HttpGet("GetDepartmentByID/{internalID}")]
        public async Task<JsonResult> GetDepartmentByIDAsync(Guid internalID)
        {
            var result = await _department.GetDepartmentByIDAsync(internalID);
            return new JsonResult(result);
        }

        [HttpPost("SaveDepartment")]
        public async Task SaveDepartmentAsync(DepartmentRequestModel model)
        {
            await _department.SaveDepartmentAsync(model);
        }
    }
}
