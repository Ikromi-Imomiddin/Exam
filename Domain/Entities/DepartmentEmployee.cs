namespace Domain.Entities;

public class DelpartmentEmployee
{
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public int EmployeeId { get; set; }
    public int DepartmentId { get; set; }
}
