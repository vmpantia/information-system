using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IS.Web.DataAccess
{
    public class Department
    {
        [Key]
        public Guid InternalID { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public Guid Manager_InternalID { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
