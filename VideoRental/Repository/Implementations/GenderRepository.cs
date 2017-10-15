using System.Data.Entity;
using VideoRental.Common.BaseRepository;
using VideoRental.EntityModel.Entities;
using VideoRental.Repository.Interfaces;

namespace VideoRental.Repository.Implementations
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(DbContext context)
            : base(context)
        {
        }
    }
}
