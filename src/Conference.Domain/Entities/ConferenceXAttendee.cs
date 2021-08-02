namespace Conference.Domain.Entities
{
    public class ConferenceXAttendee
    {
        public string AttendeeEmail { get; set; }
        public int ConferenceId { get; set; }
        public int StatusId { get; set; }
    }
}