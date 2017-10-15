using System.Data.Entity;
using VideoRental.Common.BaseRepository;
using VideoRental.EntityModel.Entities;
using VideoRental.Repository.IRepositories;

namespace VideoRental.Repository.Implementations
{
    public class UserDetailRepository : BaseRepository<UserDetail>, IUserDetailRepository
    {
        public UserDetailRepository(DbContext context)
            : base(context)
        {
        }
    }
}
