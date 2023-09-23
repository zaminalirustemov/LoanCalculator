namespace LoanCalculator.Models;
public class Loan
{
    public int Id { get; set; }
    public string AppUserId { get; set; }

    public string Purpose { get; set; }
    public int Amount { get; set; }
    public string Currency { get; set; }
    public int Duration { get; set; }
    public int Interest { get; set; }
    public string Guarantor { get; set; }

    public AppUser? AppUser { get; set; }
}