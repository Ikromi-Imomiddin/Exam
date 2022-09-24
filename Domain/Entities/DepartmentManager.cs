namespace Domain.Entities;

public class MentorGroup
{
    public int DepartmentId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}
