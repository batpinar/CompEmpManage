using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyEmployeeManagement.Web.Models;

public class Employee : BaseEntity
{

    [DisplayName("Identity Number")]
    //[StringLength(12, ErrorMessage = "Identity Number cannot exceed 11 digits.")]
    public string IdentityNumber { get; set; }


    [DisplayName("First Name")]
    //[StringLength(50)]
    public string FirstName { get; set; }

    
    [DisplayName("Last Name")]
    //[StringLength(50)]
    public string LastName { get; set; }


    [DisplayName("Company Id")]
    public int CompanyId { get; set; }


    public virtual Company Company { get; set; }

}
