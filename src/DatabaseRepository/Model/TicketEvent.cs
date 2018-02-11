namespace TicketSystem.DatabaseRepository.Model
{
    public class TicketEvent
    {
        public int TicketEventId { get; set; }
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }
        public int EventDelete { get; set; }
        public string EventUpdate { get; set; }
    }
}
