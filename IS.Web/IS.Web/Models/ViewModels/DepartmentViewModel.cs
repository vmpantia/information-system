using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IS.Web.Models
{
    public class DepartmentViewModel
    {
        public string FunctionID { get; set; }

        //Department General Information
        public Guid InternalID { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        public Guid Manager_InternalID { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

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
