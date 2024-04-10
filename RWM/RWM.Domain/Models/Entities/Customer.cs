using RWM.Domain.Contractors.Entities;
using RWM.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace RWM.Domain.Models.Entities
{
    public class Customer : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        
        // License Details
        public string LicenseNo { get; set; }
        public DateTime LicenseExpiredAt { get; set; }
        public string LicenseRestrictionCodes { get; set; }

        public CommonStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
