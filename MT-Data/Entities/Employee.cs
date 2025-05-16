namespace MT_Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table(nameof(Employee))]
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string TenantId { get; set; }
}
