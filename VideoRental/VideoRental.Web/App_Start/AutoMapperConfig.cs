using AutoMapper;
using VideoRental.EntityModel.Entities;
using VideoRental.ViewModel.Account;
using VideoRental.ViewModel.Views;

namespace VideoRental.Web.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            Mapper.CreateMap<RegisterViewModel, UserDetail>();
            Mapper.CreateMap<UserDetailView, UserDetail>();
            Mapper.CreateMap<UserDetail, UserDetailView>();
        }
    }
}