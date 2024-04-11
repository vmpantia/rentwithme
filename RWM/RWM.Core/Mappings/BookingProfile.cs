using AutoMapper;
using RWM.Core.Models.Views;
using RWM.Domain.Models.Entities;

namespace RWM.Core.Mappings
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingView>()
                .ForMember(p => p.Status, o => o.MapFrom(s => s.Status.ToString()))
                .ForMember(p => p.CustomerId, o => o.MapFrom(s => s.Customer.Id))
                .ForMember(p => p.CustomerName, o => o.MapFrom(s => string.Concat(s.Customer.FirstName, " ", s.Customer.LastName)))
                .ForMember(p => p.CustomerEmail, o => o.MapFrom(s => s.Customer.Email))
                .ForMember(p => p.CustomerContactNo, o => o.MapFrom(s => s.Customer.ContactNo))
                .ForMember(p => p.VehicleId, o => o.MapFrom(s => s.Vehicle.Id))
                .ForMember(p => p.VehicleMVFileNo, o => o.MapFrom(s => s.Vehicle.MVFileNo))
                .ForMember(p => p.VehiclePlateNo, o => o.MapFrom(s => s.Vehicle.PlateNo))
                .ForMember(p => p.VehicleFuel, o => o.MapFrom(s => s.Vehicle.Fuel))
                .ForMember(p => p.VehicleMake, o => o.MapFrom(s => s.Vehicle.Make))
                .ForMember(p => p.VehicleSeries, o => o.MapFrom(s => s.Vehicle.Series))
                .ForMember(p => p.VehicleYearModel, o => o.MapFrom(s => s.Vehicle.YearModel))
                .ForMember(p => p.VehicleType, o => o.MapFrom(s => s.Vehicle.VehicleType.Name))
                .ForMember(p => p.LastModifiedAt, o => o.MapFrom(s => s.UpdatedAt ?? s.CreatedAt));
        }
    }
}
