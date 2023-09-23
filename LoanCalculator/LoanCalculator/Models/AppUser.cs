using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.Models;
public class AppUser: IdentityUser
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
}