namespace CoreStoreCRM.Models
{
    public class Appeal
    {
        public int AppealId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public int AppealStatusId { get; set; }
        public string AppealStatus { get; set; }
        public int UserId { get; set; }
        public string ClientName { get; set; }
        public int EmployeeId { get; set; }
        public string ManagerName { get; set; }
        public int AppealTypeId { get; set; }
        public string AppealType { get; set; }
    }
}
