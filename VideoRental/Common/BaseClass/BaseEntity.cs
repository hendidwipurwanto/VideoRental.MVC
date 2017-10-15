using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoRental.Common.BaseClass
{
    public class BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public string Id { get; set; }

        [Column(Order = 2)]
        public DateTime? CreatedTime { get; set; }

        [Column(Order = 3)]
        public string CreatedBy { get; set; }

        [Column(Order = 4)]
        public DateTime? ModifiedTime { get; set; }

        [Column(Order = 5)]
        public string ModifiedBy { get; set; }

        [Column(Order = 6)]
        public bool IsDeleted { get; set; }

        [NotMapped]
        public string UserRole { get; set; }
    }
}
