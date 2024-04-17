namespace RWM.Domain.Models.Views
{
    public class PaymentView
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string? Remarks { get; set; }
        public string Type { get; set; }
        public string Method { get; set; }
        public string Status { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}
