using System.ComponentModel.DataAnnotations;
namespace EmployeeAppManagement.Models
{
  public class EmployeeViewModel
    {
      [Display(Name = "Employee ID on the List")]
      public int EmployeeId { get; set; }

      [Display(Name = "First Name")]
      public string? FirstName { get; set; }

      [Display(Name = "Last Name")]
      public string? LastName { get; set; }

      [Display(Name = "Email")]
      public string? Email { get; set; }

      [Display(Name = "Office Phone No.")]
      public string? OfficePhone { get; set; }
      
      [Display(Name = "Employee Photo URL")]
      public string? PhotoURL { get; set; }
    }
}
