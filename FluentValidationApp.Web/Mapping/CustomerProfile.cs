using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // IncludeMembers yaptığımız için CreditCard'ı da mapledik.
            CreateMap<CreditCard, CustomerDto>();

            CreateMap<Customer, CustomerDto>().IncludeMembers(x=>x.CreditCard)
                .ForMember(dest => dest.Isim, opt => opt.MapFrom(a => a.Name))
                .ForMember(dest => dest.Eposta, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age));
        }
    }
}
