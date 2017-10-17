using VideoRental.Common.BaseService;
using VideoRental.EntityModel.Entities;
using VideoRental.Repository.Interfaces;
using VideoRental.Service.Interfaces;

namespace VideoRental.Service.Implementations
{
    public class GenderService : BaseService<Gender>, IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
            : base(genderRepository)
        {
            _genderRepository = genderRepository;
        }
    }
}
