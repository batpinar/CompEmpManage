using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployeeManagement.Web.Models;

public class Employee
{
    public int Id { get; set; }
    //[DisplayName("Identity Number")]
    //[Column(TypeName = "nvarchar(11)")]
    [Required]
    public string IdentityNumber { get; set; }

    //[Column(TypeName = "nvarchar(50)")]
    //[DisplayName("First Name")]
    public string FirstName { get; set; }

    //[Column(TypeName = "nvarchar(50)")]
    //[DisplayName("Last Name")]
    public string LastName { get; set; }

    //[DisplayName("Company Id")]
    public int CompanyId { get; set; }

    public virtual Company Company { get; set; }

}
