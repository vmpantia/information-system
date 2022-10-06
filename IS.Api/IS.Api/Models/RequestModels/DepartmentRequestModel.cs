using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IS.Web.Models
{
    public class DepartmentRequestModel
    {
        public string FunctionID { get; set; }
        public Guid InternalID { get; set; }
        public string Name { get; set; }
        public Guid Manager_InternalID { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public ClientInformation client { get; set; }
    }
}
