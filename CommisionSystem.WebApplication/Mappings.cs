using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.WebApplication
{
    public class Mappings:Profile
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

            CreateMap<Models.ViewModels.EditUserModel, Entities.User>();
            CreateMap<Models.ViewModels.CreateUserModel, Entities.User>();

            CreateMap<Entities.Product, Models.ViewModels.ReadProductModel>()
                .ForMember(dest =>
                        dest.ProductName,
                        opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                        dest.Brand,
                        opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest =>
                    dest.PriceInRials,
                    opt => opt.MapFrom(src => string.Format("{0:N0}", src.PriceInRials)));
        }
    }
}
