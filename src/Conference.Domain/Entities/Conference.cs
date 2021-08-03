using System;

namespace Conference.Domain.Entities
{
    public class Conference
    {
        public int Id { get; set; }
        public string OrganizerEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
    }
}