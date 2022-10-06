using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IS.Web.DataAccess
{
    public class Position_MST
    {
        [Key]
        public Guid InternalID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Guid Department_InternalID { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
