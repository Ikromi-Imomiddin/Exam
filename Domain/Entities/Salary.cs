namespace Domain.Entities;

public class Group
{
    public int EmployeeId { get; set; }
    public int Id { get; set; }
    public string? Amount { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}
