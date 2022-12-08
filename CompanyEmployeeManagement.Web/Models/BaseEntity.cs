using System.ComponentModel.DataAnnotations;

namespace CompanyEmployeeManagement.Web.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; } 
}
