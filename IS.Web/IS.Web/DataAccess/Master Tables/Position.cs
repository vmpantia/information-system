using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IS.Web.DataAccess
{
    public class Position
    {
        [Key]
        public Guid InternalID { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public Guid Department_InternalID { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
