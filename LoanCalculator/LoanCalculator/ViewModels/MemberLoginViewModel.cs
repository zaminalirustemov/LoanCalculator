using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.ViewModels;
public class MemberLoginViewModel
{
    [Required]
    [StringLength(maximumLength: 10)]
    public string FIN { get; set; }

    [Required]
    [StringLength(maximumLength: 20, MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}