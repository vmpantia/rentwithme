using Bogus;
using Bogus.Extensions.UnitedStates;
using RWM.Domain.Models.Entities;
using RWM.Domain.Models.Enums;

namespace RWM.Domain.Stubs
{
    public class FakeData
    {
        public static Faker<Booking> FakerBooking(IEnumerable<Guid> customerIds, IEnumerable<Guid> vehicleIds) =>
            new Faker<Booking>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.CustomerId, f => f.PickRandom(customerIds))
                .RuleFor(p => p.VehicleId, f => f.PickRandom(vehicleIds))
                .RuleFor(p => p.StartAt, f => f.Date.Past())
                .RuleFor(p => p.EndAt, f => f.Date.Future())
                .RuleFor(p => p.Destination, f => f.Address.City())
                .RuleFor(p => p.Rate, f => f.Random.Decimal())
                .RuleFor(p => p.Feedback, f => f.Lorem.Sentence())
                .RuleFor(p => p.Status, f => f.PickRandom<BookingStatus>())
                .RuleFor(p => p.CreatedAt, DateTime.Now)
                .RuleFor(p => p.CreatedBy, f => f.Internet.Email());

        public static Faker<Customer> FakerCustomer() =>
            new Faker<Customer>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.MiddleName, f => f.Name.Suffix())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.ContactNo, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Address, f => f.Address.City())
                .RuleFor(p => p.Gender, f => f.PickRandom<Gender>())
                .RuleFor(p => p.LicenseNo, f => f.Company.Ein())
                .RuleFor(p => p.LicenseExpiredAt, f => f.Date.Future())
                .RuleFor(p => p.LicenseRestriction, f => f.Company.Ein())
                .RuleFor(p => p.Status, f => f.PickRandom<CommonStatus>())
                .RuleFor(p => p.CreatedAt, DateTime.Now)
                .RuleFor(p => p.CreatedBy, f => f.Internet.Email());

        public static Faker<Operator> FakerOperator() =>
            new Faker<Operator>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.MiddleName, f => f.Name.Suffix())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.ContactNo, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Address, f => f.Address.City())
                .RuleFor(p => p.Gender, f => f.PickRandom<Gender>())
                .RuleFor(p => p.Status, f => f.PickRandom<CommonStatus>())
                .RuleFor(p => p.CreatedAt, DateTime.Now)
                .RuleFor(p => p.CreatedBy, f => f.Internet.Email());

        public static Faker<Payment> FakerPayment(IEnumerable<Guid> bookingIds) =>
            new Faker<Payment>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.BookingId, f => f.PickRandom(bookingIds))
                .RuleFor(p => p.Amount, f => f.Random.Decimal())
                .RuleFor(p => p.Remarks, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Type, f => f.PickRandom<PaymentType>())
                .RuleFor(p => p.Method, f => f.PickRandom<PaymentMethod>())
                .RuleFor(p => p.CreatedAt, DateTime.Now)
                .RuleFor(p => p.CreatedBy, f => f.Internet.Email());

        public static Faker<Vehicle> FakerVehicle(IEnumerable<Guid> operatorIds, IEnumerable<Guid> vehicleTypeIds, IEnumerable<Guid> yardIds) =>
            new Faker<Vehicle>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.OperatorId, f => f.PickRandom(operatorIds))
                .RuleFor(p => p.VehicleTypeId, f => f.PickRandom(vehicleTypeIds))
                .RuleFor(p => p.YardId, f => f.PickRandom(yardIds))
                .RuleFor(p => p.MVFileNo, f => f.Vehicle.Vin())
                .RuleFor(p => p.PlateNo, f => f.Vehicle.Vin())
                .RuleFor(p => p.EngineNo, f => f.Vehicle.Vin())
                .RuleFor(p => p.ChassisNo, f => f.Vehicle.Vin())
                .RuleFor(p => p.Fuel, f => f.Vehicle.Fuel())
                .RuleFor(p => p.Make, f => f.Vehicle.Manufacturer())
                .RuleFor(p => p.Series, f => f.Vehicle.Model())
                .RuleFor(p => p.YearModel, f => f.Date.Future().Year.ToString())
                .RuleFor(p => p.ExpiredAt, f => f.Date.Future())
                .RuleFor(p => p.Rate, f => f.Random.Decimal())
                .RuleFor(p => p.Status, f => f.PickRandom<VehicleStatus>())
                .RuleFor(p => p.CreatedAt, DateTime.Now)
                .RuleFor(p => p.CreatedBy, f => f.Internet.Email());

        public static Faker<VehicleType> FakerVehicleType() =>
            new Faker<VehicleType>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Name, f => f.Vehicle.Type())
                .RuleFor(p => p.Description, f => f.Vehicle.Type())
                .RuleFor(p => p.Rate, f => f.Random.Decimal())
                .RuleFor(p => p.Status, f => f.PickRandom<CommonStatus>())
                .RuleFor(p => p.CreatedAt, DateTime.Now)
                .RuleFor(p => p.CreatedBy, f => f.Internet.Email());

        public static Faker<Yard> FakerYard() =>
            new Faker<Yard>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Name, f => f.Address.City())
                .RuleFor(p => p.ContactNo, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Address, f => f.Address.FullAddress())
                .RuleFor(p => p.PICName, f => f.Name.FullName())
                .RuleFor(p => p.PICContactNo, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.PICEmail, f => f.Internet.Email())
                .RuleFor(p => p.Status, f => f.PickRandom<CommonStatus>())
                .RuleFor(p => p.CreatedAt, DateTime.Now)
                .RuleFor(p => p.CreatedBy, f => f.Internet.Email());
    }
}
