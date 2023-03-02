namespace DataAccess.Models;
public record Department
{
    public string DName { get; set; }
    public int DNumber { get; set; }
    public int MgrSSN { get; set; }
    public DateTime MgrStartDate { get; set; }
    public int? EmpCount { get; set; }

    public override string ToString()
    {
        return $"Department: {DName} (#{DNumber})\nManager: {MgrSSN} (since {MgrStartDate.ToShortDateString()})\nTotal employees: {EmpCount}";
    }
}
