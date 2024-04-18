namespace RWM.Domain.Models.Views
{
    public class BookingView
    {
        public Guid Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int Days { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Rate { get; set; }
        public decimal ReservationPercentage { get; set; }
        public decimal Total { get; set; }
        public decimal ReservationFee { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Balance { get; set; }
        public string? Feedback { get; set; }
        public string Status { get; set; }

        // Customer Information
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerContactNo { get; set; }

        // Vehicle Information
        public Guid VehicleId { get; set; }
        public string VehicleMVFileNo { get; set; }
        public string VehiclePlateNo { get; set; }
        public string VehicleFuel { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleSeries { get; set; }
        public string VehicleYearModel { get; set; }
        public string VehicleType { get; set; }

        // Payment Information
        public IEnumerable<PaymentView> PaymentHistory { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}
