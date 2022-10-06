﻿using System.ComponentModel.DataAnnotations;

namespace IS.Web.DataAccess
{
    public class Department_TRN
    {
        [Key]
        [MaxLength(15)]
        public string RequestID { get; set; }
        public Guid InternalID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Guid Manager_InternalID { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}