namespace CoreStoreCRM.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Contacts { get; set; }
        public int PositionId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
    }
}
