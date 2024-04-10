using RWM.Domain.Contractors.Entities;
using RWM.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace RWM.Domain.Models.Entities
{
    public class Payment : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
        public string? Remarks { get; set; }
        public PaymentType Type { get; set; }
        public PaymentMethod Method { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
