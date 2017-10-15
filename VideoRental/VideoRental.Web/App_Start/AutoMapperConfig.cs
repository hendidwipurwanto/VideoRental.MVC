using AutoMapper;
using VideoRental.EntityModel.Entities;
using VideoRental.ViewModel.Account;

namespace VideoRental.Web.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            Mapper.CreateMap<RegisterViewModel, UserDetail>();

        }
    }
}