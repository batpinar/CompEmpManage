using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyEmployeeManagement.Web.Models;

public class Company : BaseEntity
{
    [DisplayName("Company Name")]
    public string CompanyName { get; set; }

    [DisplayName("Tax Number")]
    //[StringLength(11,ErrorMessage = "Tax Nubmer cannot exceed 10 digits.")]
    public string TaxNumber { get; set; }

    [DisplayName("Tax Office")]
    public string TaxOffice { get; set; }

    [DisplayName("Employee Count")]
    //[MaxLength(100000)]
    //public int EmployeeCount { get; set; }

    //[StringLength(300)]
    public string Adresses { get; set; }



}
