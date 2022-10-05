using IS.Web.DataAccess;
using IS.Web.Models;

namespace IS.Web.Controllers
{
    public static class UtilityController
    {
        public static DepartmentViewModel GetDepartmentViewModel(string FunctionID, Department_MST department = null)
        {
            var viewModel = new DepartmentViewModel();
            viewModel.FunctionID = FunctionID; 

            if(department != null)
            {
                viewModel.InternalID = department.InternalID;
                viewModel.Name = department.Name;
                viewModel.Manager_InternalID = department.Manager_InternalID;
                viewModel.Status = department.Status;
                viewModel.CreatedDate = department.CreatedDate;
                viewModel.ModifiedDate = department.ModifiedDate;
            }
            return viewModel;
        }
    }
}
