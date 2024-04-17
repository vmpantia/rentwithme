using RWM.Domain.Contractors.Entities;
using RWM.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace RWM.Domain.Models.Entities
{
    public class Booking : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Destination { get; set; }
        public decimal Rate { get; set; }
        public string? Feedback { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
