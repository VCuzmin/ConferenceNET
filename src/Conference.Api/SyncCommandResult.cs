namespace Conference.Api
{
    public class SyncCommandResult<T>
    {
        public T Event { get; set; }
        public string ErrorMessage { get; set; }

        public SyncCommandResult(T @event, string errorMessage)
        {
            ErrorMessage = errorMessage;
            Event = @event;
        }
    }
}