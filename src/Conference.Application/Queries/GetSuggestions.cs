using NBB.Application.DataContracts;

namespace Conference.Application.Queries
{
    public class GetSuggestions
    {
        public class Query : Query<Model>
        {
            public string AttendeeEmail { get; set; }
            public int ConferenceId { get; set; }
        }

        public class Model
        {
           
        }
    }
}