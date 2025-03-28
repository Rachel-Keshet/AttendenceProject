namespace AttendenceP.Models
{
    public class HourPostModel
    {
        public int Id { get; set; }
        public DateTime AttendDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int UserId { get; set; }
    }
}
