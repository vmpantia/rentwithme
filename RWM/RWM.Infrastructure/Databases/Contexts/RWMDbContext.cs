using Microsoft.EntityFrameworkCore;
using RWM.Domain.Models.Entities;

namespace RWM.Infrastructure.Databases.Contexts
{
    public class RWMDbContext : DbContext
    {
        public RWMDbContext(DbContextOptions options) : base(options) { }

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
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasMany(c => c.Bookings)
                .WithOne(b => b.Customer)
                .HasForeignKey( c => c.CustomerId)
                .IsRequired();
            });

            modelBuilder.Entity<Operator>(e =>
            {
                e.HasMany(o => o.Vehicles)
                .WithOne(v => v.Operator)
                .HasForeignKey(v => v.OperatorId)
                .IsRequired();
            });

            modelBuilder.Entity<Payment>(e =>
            {
                e.HasOne(p => p.Booking)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.BookingId)
                .IsRequired();
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
            });

            modelBuilder.Entity<VehicleType>(e =>
            {
                e.HasMany(vt => vt.Vehicles)
                .WithOne(v => v.VehicleType)
                .HasForeignKey(v => v.VehicleTypeId)
                .IsRequired();
            });

            modelBuilder.Entity<Yard>(e =>
            {
                e.HasMany(vt => vt.Vehicles)
                .WithOne(y => y.Yard)
                .HasForeignKey(y => y.YardId)
                .IsRequired();
            });
        }
    }
}
