using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Services
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Data.Sepidar.Brand, Entities.Brand>();

            CreateMap<Data.Sepidar.FiscalYear, Entities.FiscalYear>();

            CreateMap<Data.Role, Entities.Role>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.RoleName));

            CreateMap<Data.Sepidar.Product, Entities.Product>()
                .ForMember(dest =>
                    dest.UnitsInStock,
                    opt => opt.MapFrom(src => Convert.ToInt32(src.Stock)))
                 .ForMember(dest =>
                    dest.SumStock,
                    opt => opt.MapFrom(src => Convert.ToInt32(src.SumStock)));

            CreateMap<Data.User, Entities.User>()
                .ForMember(dest=>
                dest.Policies,
                opt=>opt.MapFrom(src=>src.UserPolicies.Select(a=>a.Policy)));

            CreateMap<Data.Policy, Entities.Policy>();

        }
    }
}
