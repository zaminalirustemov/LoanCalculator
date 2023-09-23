using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.ViewModels;
public class MemberRegisterViewModel
{
    [StringLength(maximumLength: 100)]
    public string ActualAddress { get; set; }
    [StringLength(maximumLength: 100)]
    public string SerialNumber { get; set; }

    [StringLength(maximumLength: 10)]
    public string FIN { get; set; }
    [StringLength(maximumLength: 100)]
    public string Name { get; set; }
    [StringLength(maximumLength: 100)]
    public string Surname { get; set; }
    [StringLength(maximumLength: 100)]
    public string FatherName { get; set; }
    [StringLength(maximumLength: 100)]
    public string RegistrationAddress { get; set; }
    public DateTime DateOfBirth { get; set; }
    [StringLength(maximumLength: 100)]
    public string PhoneNumber { get; set; }
    [StringLength(maximumLength: 20, MinimumLength = 8), DataType(DataType.Password)]
    public string Password { get; set; }
    [StringLength(maximumLength: 20, MinimumLength = 8), DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}