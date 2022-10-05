using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IS.Web.DataAccess
{
    public class Department_TRN
    {
        [Key]
        [MaxLength(15)]
        public string RequestID { get; set; }
        public Guid InternalId { get; set; }
        public string Name { get; set; }
        public Guid Manager_InternalId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
