namespace Domain.Models;

public class Teacher
{
    public int id { get; set; }
    public required string fullname { get; set; }
    public string subject { get; set; }
    public int experience { get; set; }
}