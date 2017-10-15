using System;
using System.ComponentModel.DataAnnotations.Schema;
using VideoRental.Common.BaseClass;

namespace VideoRental.EntityModel.Entities
{
    public class UserDetail : BaseEntity
    {
        public string FristName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthOfDate { get; set; }

        public string Address { get; set; }

        [ForeignKey("Gender")]
        public string GenderId { get; set; }

        public virtual Gender Gender { get; set; }
    }
}
