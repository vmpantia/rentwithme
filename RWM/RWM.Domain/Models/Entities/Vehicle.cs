using RWM.Domain.Contractors.Entities;
using RWM.Domain.Models.Enums;

namespace RWM.Domain.Models.Entities
{
    public class Vehicle : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid VehicleTypeId { get; set; }
        public string MVFileNo { get; set; }
        public string PlateNo { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string Fuel { get; set; }
        public string Make { get; set; }
        public string Series { get; set; }
        public string YearModal { get; set; }
        public DateTime ORExpiredAt { get; set; }
        public decimal Rate { get; set; }
        public VehicleStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
