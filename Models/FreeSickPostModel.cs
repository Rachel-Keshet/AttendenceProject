namespace AttendenceP.Models
{
    public class FreeSickPostModel
    {
        public int Id { get; set; }
        public string? DayType { get; set; }
        public DateTime FreeDate { get; set; }

        public bool IsApproved { get; set; }
        public int UserId { get; set; }
    }
}
