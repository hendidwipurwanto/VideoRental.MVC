using System;
using VideoRental.Common.BaseClass;
using VideoRental.EntityModel.Entities;

namespace VideoRental.ViewModel.Views
{
    public class UserDetailView : BaseView
    {
        public string Id { get; set; }

        public string FristName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthOfDate { get; set; }

        public string Address { get; set; }

        public string GenderId { get; set; }

        public Gender Gender { get; set; }
    }
}
