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

        [HttpGet("GetDepartmentList")]
        public async Task<JsonResult> GetDepartmentListAsync()
        {
            var setting = new FilterSetting();
            var result = await _department.GetDepartmentListAsync(setting);
            return new JsonResult(result);
        }

        [HttpGet("GetDepartmentByID/{internalID}")]
        public async Task<JsonResult> GetDepartmentByIDAsync(Guid internalID)
        {
            var result = await _department.GetDepartmentByIDAsync(internalID);
            return new JsonResult(result);
        }

        [HttpPost("SaveDepartment")]
        public async Task<JsonResult> SaveDepartmentAsync(DepartmentRequestModel model)
        {
            var result = await _department.SaveDepartmentAsync(model);
            return new JsonResult(result);
        }
    }
}
