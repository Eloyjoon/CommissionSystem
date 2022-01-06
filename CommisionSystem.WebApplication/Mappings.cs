using AutoMapper;
using CommissionSystem.Business.User;

namespace CommissionSystem.WebApplication
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Entities.FiscalYear, Models.ViewModels.ReadFiscalYearModel>();

            CreateMap<Entities.Brand, Models.ViewModels.ReadBrandModel>()
                    .ForMember(dest =>
                        dest.Title,
                        opt => opt.MapFrom(src => src.Name));

            CreateMap<Entities.User, Models.ViewModels.ReadUserModel>()
                .ForMember(dest =>
                    dest.RoleName,
                    opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest =>
                    dest.UserID,
                    opt => opt.MapFrom(src => src.ID));

            CreateMap<Models.ViewModels.EditUserModel, Entities.User>()
                .ForMember(dest =>
                    dest.ID,
                    opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest =>
                    dest.Role,
                    opt => opt.MapFrom(src => new Entities.Role() { ID = src.RoleID }));

            CreateMap<CreateUserModel, Entities.User>()
                .ForMember(dest =>
                    dest.Role,
                    opt => opt.MapFrom(src => new Entities.Role() { ID = src.RoleID }));

            CreateMap<Entities.Policy, Models.ViewModels.ReadPolicyModel>()
                    .ForMember(dest =>
                        dest.Title,
                        opt => opt.MapFrom(src => src.Name));

            CreateMap<Entities.Product, Models.ViewModels.ReadProductModel>()
                .ForMember(dest =>
                        dest.ProductName,
                        opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                        dest.Brand,
                        opt => opt.MapFrom(src => src.Brand.Name))
                //.ForMember(dest =>
                //        dest.Store,
                //        opt => opt.MapFrom(src => src.JoinedStores))
                .ForMember(dest =>
                    dest.PriceInRials,
                    opt => opt.MapFrom(src => string.Format("{0:N0}", src.PriceInRials)));
        }
    }
}
