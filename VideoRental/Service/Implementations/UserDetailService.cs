using VideoRental.Common.BaseService;
using VideoRental.EntityModel.Entities;
using VideoRental.Repository.Interfaces;
using VideoRental.Service.Interfaces;

namespace VideoRental.Service.Implementations
{
    public class UserDetailService : BaseService<UserDetail>, IUserDetailService
    {
        private readonly IUserDetailRepository _userDetailRepository;

        public UserDetailService(IUserDetailRepository userDetailRepository)
            : base(userDetailRepository)
        {
            _userDetailRepository = userDetailRepository;
        }
    }
}
