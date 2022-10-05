using IS.Web.Controllers;
using IS.Web.DataAccess;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IS.Web.Models
{
    public class DepartmentViewModel
    {
        public string FunctionID { get; set; }
        [CustomValidation(DepartmentViewModel), "CheckIfNameExist")]
        public Department newDepartment { get; set; }
        public Department_TRN GetDepartment_TRN(string RequestID)
        {
            if (string.IsNullOrEmpty(RequestID))
                throw new Exception("RequestID cannot be NULL or Empty");

            return new Department_TRN
            {
                RequestID = RequestID,
                InternalId = newDepartment.InternalID,
                Name = newDepartment.Name,
                Manager_InternalId = newDepartment.Manager_InternalID,
                Status = newDepartment.Status,
                CreatedDate = newDepartment.CreatedDate,
                ModifiedDate = newDepartment.ModifiedDate
            };
        }
        public IEnumerable<SelectListItem> ManagerList
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = Guid.NewGuid().ToString(),
                        Text = "Manager 1"
                    },
                    new SelectListItem
                    {
                        Value = Guid.NewGuid().ToString(),
                        Text = "Manager 2"
                    },
                };
            }
        }
    }
}
