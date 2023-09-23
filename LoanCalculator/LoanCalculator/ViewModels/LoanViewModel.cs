namespace LoanCalculator.ViewModels;
public class LoanViewModel
{
    public string Purpose { get; set; }
    public int Amount { get; set; }
    public string Currency { get; set; }
    public int Duration { get; set; }
    public int Interest { get; set; }
    public string Guarantor { get; set; }
}