namespace Conference.Domain.Entities
{
    public class ConferenceXAttendee
    {
        public int Id { get; set; }
        public string AttendeeEmail { get; set; }
        public Conference Conference { get; set; }
        public int ConferenceId { get; set; }
        public int StatusId { get; set; }
    }
}