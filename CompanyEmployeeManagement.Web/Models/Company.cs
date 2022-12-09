using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployeeManagement.Web.Models;

public class Company
{
    public int Id { get; set; }
    //[DisplayName("Company Name")]
    //[Column(TypeName = "nvarchar(150)")]
    [Required]
    public string CompanyName { get; set; }

    //[DisplayName("Tax Number")]
    //[Column(TypeName = "nvarchar(10)")]
    public string TaxNumber { get; set; }

    //[Column(TypeName = "nvarchar(150)")]
    //[DisplayName("Tax Office")]
    public string TaxOffice { get; set; }

    //[Column(TypeName = "nvarchar(300)")]
    public string Adresses { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }

}
