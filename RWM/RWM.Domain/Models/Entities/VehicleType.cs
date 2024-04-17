using RWM.Domain.Contractors.Entities;
using RWM.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace RWM.Domain.Models.Entities
{
    public class VehicleType : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; } // Suggested Rate for Specific Vehicle Type
        public CommonStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
