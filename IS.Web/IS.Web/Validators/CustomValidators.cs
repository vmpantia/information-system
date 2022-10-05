using IS.Web.Contractor;
using IS.Web.DataAccess;
using IS.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace IS.Web.Validators
{
    public class CustomValidators
    {
        public readonly IBaseRepository<Request> _request;
        public readonly IBaseRepository<Department> _department;
        public readonly IBaseRepository<Position> _position;
        public CustomValidators(IBaseRepository<Request> requestRepository,
                                   IBaseRepository<Department> departmentRepository,
                                   IBaseRepository<Position> positionRepository)
        {
            _request = requestRepository;
            _department = departmentRepository;
            _position = positionRepository;
        }

        public class CheckDepartmentNameExist : ValidationAttribute
        {
            public override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var department = (DepartmentViewModel)validationContext.ObjectInstance;
                return new ValidationResult("Department Name is already exist in Database");
            }
        }
    }
}
