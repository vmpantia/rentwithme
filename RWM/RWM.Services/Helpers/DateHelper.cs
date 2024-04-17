namespace RWM.Services.Helpers
{
    public class DateHelper
    {
        public static int GetDays(DateTime dateFrom, DateTime dateTo)
        {
            // Check if the date from is greater than date to
            if (dateFrom.Date > dateTo.Date) throw new Exception("Invalid date range value.");

            // Get number of days between the two dates
            return (dateTo.Date - dateFrom.Date).Days;
        }
    }
}
