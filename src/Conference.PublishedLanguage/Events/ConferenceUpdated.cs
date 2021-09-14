using MediatR;
using System;

namespace Conference.PublishedLanguage.Events
{
    public class ConferenceUpdated : INotification
    {
        public int Id { get; set; }
        public string OrganizerEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public int ConferenceTypeId { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
    }
}
