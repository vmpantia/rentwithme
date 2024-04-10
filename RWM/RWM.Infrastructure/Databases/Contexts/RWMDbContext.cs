using Microsoft.EntityFrameworkCore;
using RWM.Domain.Models.Entities;
using RWM.Domain.Stubs;

namespace RWM.Infrastructure.Databases.Contexts
{
    public class RWMDbContext : DbContext
    {
        private List<Booking> _stubBookings = new List<Booking>();
        private List<Customer> _stubCustomers = new List<Customer>();
        private List<Operator> _stubOperators = new List<Operator>();
        private List<Payment> _stubPayments = new List<Payment>();
        private List<Vehicle> _stubVehicles = new List<Vehicle>();
        private List<VehicleType> _stubVehicleTypes = new List<VehicleType>();
        private List<Yard> _stubYards = new List<Yard>();
        public RWMDbContext(DbContextOptions options) : base(options)
        {
            var customers = FakeData.FakerCustomer()
                                    .Generate(100);
            var operators = FakeData.FakerOperator()
                                    .Generate(100);
            var vehicleTypes = FakeData.FakerVehicleType()
                                       .Generate(10);
            var yards = FakeData.FakerYard()
                                .Generate(10);
            var vehicles = FakeData.FakerVehicle(operators.Select(data => data.Id),
                                                 vehicleTypes.Select(data => data.Id),
                                                 yards.Select(data => data.Id))
                                   .Generate(500);
            var bookings = FakeData.FakerBooking(customers.Select(data => data.Id),
                                                 vehicles.Select(data => data.Id))
                                   .Generate(1000);
            var payments = FakeData.FakerPayment(bookings.Select(data => data.Id))
                                   .Generate(1000);

            _stubBookings = bookings;
            _stubCustomers = customers;
            _stubOperators = operators;
            _stubPayments = payments;
            _stubVehicles = vehicles;
            _stubVehicleTypes = vehicleTypes;
            _stubYards = yards;
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Yard> Yards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(e =>
            {
                e.HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId)
                .IsRequired();

                e.HasOne(b => b.Vehicle)
                .WithMany(v => v.Bookings)
                .HasForeignKey(b => b.VehicleId)
                .IsRequired();

                e.HasMany(b => b.Payments)
                .WithOne(p => p.Booking)
                .HasForeignKey(p => p.BookingId)
                .IsRequired();

                e.Property(b => b.Amount)
                .HasPrecision(18, 2);

                e.HasData(_stubBookings);
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasMany(c => c.Bookings)
                .WithOne(b => b.Customer)
                .HasForeignKey( c => c.CustomerId)
                .IsRequired();

                e.HasData(_stubCustomers);
            });

            modelBuilder.Entity<Operator>(e =>
            {
                e.HasMany(o => o.Vehicles)
                .WithOne(v => v.Operator)
                .HasForeignKey(v => v.OperatorId)
                .IsRequired();

                e.HasData(_stubOperators);
            });

            modelBuilder.Entity<Payment>(e =>
            {
                e.HasOne(p => p.Booking)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.BookingId)
                .IsRequired();

                e.Property(b => b.Amount)
                .HasPrecision(18, 2);

                e.HasData(_stubPayments);
            });

            modelBuilder.Entity<Vehicle>(e =>
            {
                e.HasOne(v => v.Operator)
                .WithMany(o => o.Vehicles)
                .HasForeignKey(v => v.OperatorId)
                .IsRequired();

                e.HasOne(v => v.VehicleType)
                .WithMany(vt => vt.Vehicles)
                .HasForeignKey(v => v.VehicleTypeId)
                .IsRequired();

                e.HasOne(v => v.Yard)
                .WithMany(y => y.Vehicles)
                .HasForeignKey(v => v.YardId)
                .IsRequired();

                e.HasMany(v => v.Bookings)
                .WithOne(b => b.Vehicle)
                .HasForeignKey(v => v.VehicleId)
                .IsRequired();

                e.Property(b => b.Rate)
                .HasPrecision(18, 2);

                e.HasData(_stubVehicles);
            });

            modelBuilder.Entity<VehicleType>(e =>
            {
                e.HasMany(vt => vt.Vehicles)
                .WithOne(v => v.VehicleType)
                .HasForeignKey(v => v.VehicleTypeId)
                .IsRequired();

                e.Property(b => b.Rate)
                .HasPrecision(18, 2);

                e.HasData(_stubVehicleTypes);
            });

            modelBuilder.Entity<Yard>(e =>
            {
                e.HasMany(vt => vt.Vehicles)
                .WithOne(y => y.Yard)
                .HasForeignKey(y => y.YardId)
                .IsRequired();

                e.HasData(_stubYards);
            });
        }
    }
}
