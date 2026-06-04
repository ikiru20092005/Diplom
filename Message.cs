namespace CoreStoreCRM.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public bool IsFromManager { get; set; }
        public string MessageText { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int AppealId { get; set; }
    }
}
