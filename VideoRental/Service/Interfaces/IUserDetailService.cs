using System.Collections.Generic;
using VideoRental.Common.BaseService;
using VideoRental.EntityModel.Entities;
using VideoRental.ViewModel.Views;

namespace VideoRental.Service.Interfaces
{
    public interface IUserDetailService : IBaseService<UserDetail>
    {
        List<UserDetailView> GetUserDetailViewList();
        UserDetailView UpdateUserDetailView(UserDetailView userDetailView);
    }
}
