using AutoMapper;
using RWM.Domain.Models.Entities;
using RWM.Domain.Models.Views;

namespace RWM.Core.Mappings
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentView>()
                .ForMember(p => p.Type, o => o.MapFrom(s => s.Type.ToString()))
                .ForMember(p => p.Method, o => o.MapFrom(s => s.Method.ToString()))
                .ForMember(p => p.Status, o => o.MapFrom(s => s.Status.ToString()))
                .ForMember(p => p.LastModifiedAt, o => o.MapFrom(s => s.UpdatedAt ?? s.CreatedAt));
        }
    }
}
