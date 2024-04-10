using AutoMapper;
using RWM.Core.Models.Views;
using RWM.Domain.Models.Entities;

namespace RWM.Core.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerView>()
                .ForMember(p => p.Gender, o => o.MapFrom(s => s.Gender.ToString()))
                .ForMember(p => p.Status, o => o.MapFrom(s => s.Status.ToString()))
                .ForMember(p => p.LastModifiedAt, o => o.MapFrom(s => s.UpdatedAt ?? s.CreatedAt));
        }
    }
}
