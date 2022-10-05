using System.ComponentModel.DataAnnotations;

namespace IS.Web.DataAccess
{
    public class Request_LST
    {
        [Key]
        public string RequestID { get; set; }
        public string FunctionID { get; set; }
        public string Status { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
