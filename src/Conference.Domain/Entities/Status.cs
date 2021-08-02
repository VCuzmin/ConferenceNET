using NBB.Domain;
using Newtonsoft.Json;

namespace Conference.Domain.Entities
{
    public class Status : Enumeration
    {
        public static readonly Status Joined = new Status(1, nameof(Joined));
        public static readonly Status Withdrawn = new Status(2, nameof(Withdrawn));
        public static readonly Status Attended = new Status(3, nameof(Attended));

        [JsonConstructor]
        public Status(int id, string name) : base(id, name)
        {
        }
    }
}