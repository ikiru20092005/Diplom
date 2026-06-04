namespace CoreStoreCRM.Models
{
    public class Notification
    {
        public int MessageId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string MessageText { get; set; }
        public int AppealId { get; set; }
    }
}
