namespace CoreStoreCRM.Models
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int MessageId { get; set; }
    }
}
