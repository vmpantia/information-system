using IS.Web.DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IS.Web.Models
{
    public class DepartmentRequestModel
    {
        public string FunctionID { get; set; }
        public Department_MST department { get; set; }
        public ClientInformation client { get; set; }
    }
}
