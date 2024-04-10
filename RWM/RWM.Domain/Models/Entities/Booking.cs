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
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Amount { get; set; }
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
