using RWM.Domain.Contractors.Entities;
using RWM.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace RWM.Domain.Models.Entities
{
    public class Vehicle : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OperatorId { get; set; }
        public Guid VehicleTypeId { get; set; }
        public Guid YardId { get; set; }
        public string MVFileNo { get; set; }
        public string PlateNo { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string Fuel { get; set; }
        public string Make { get; set; }
        public string Series { get; set; }
        public string YearModel { get; set; }
        public DateTime ExpiredAt { get; set; }
        public decimal Rate { get; set; }
        public VehicleStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

        public virtual Operator Operator { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual Yard Yard { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
