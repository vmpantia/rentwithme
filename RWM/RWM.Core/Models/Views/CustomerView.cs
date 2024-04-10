namespace RWM.Core.Models.Views
{
    public class CustomerView
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string LicenseNo { get; set; }
        public DateTime LicenseExpiredAt { get; set; }
        public string LicenseRestrictionCodes { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}
