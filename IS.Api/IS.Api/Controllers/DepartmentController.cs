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
        public async Task<ActionResult> GetDepartmentListAsync()
        {
            try
            {
                var setting = new FilterSetting();
                var result = await _department.GetDepartmentListAsync(setting);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDepartmentByID/{internalID}")]
        public async Task<ActionResult> GetDepartmentByIDAsync(Guid internalID)
        {
            try
            {
                var setting = new FilterSetting();
                var result = await _department.GetDepartmentByIDAsync(internalID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("IsDepartmentNameExist/{name}")]
        public async Task<ActionResult> IsDepartmentNameExistAsync(string name)
        {
            try 
            { 
                var result = await _department.IsDepartmentNameExistAsync(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveDepartment")]
        public async Task<ActionResult> SaveDepartmentAsync(DepartmentRequestModel model)
        {
            try
            {
                var result = await _department.SaveDepartmentAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
