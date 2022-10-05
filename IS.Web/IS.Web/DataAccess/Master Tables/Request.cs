using System.ComponentModel.DataAnnotations;

namespace IS.Web.DataAccess
{
    public class Request
    {
        [Key]
        [MaxLength(15)]
        public string RequestID { get; set; }
        [MaxLength(5)]
        public string FunctionID { get; set; }
        [MaxLength(2)]
        public string Status { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
