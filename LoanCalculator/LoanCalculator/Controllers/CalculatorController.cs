using LoanCalculator.Context;
using LoanCalculator.Models;
using LoanCalculator.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoanCalculator.Controllers;
public class CalculatorController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly LoanCalculatorDbContext _context;

    public CalculatorController(UserManager<AppUser> userManager, LoanCalculatorDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Calculate()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Calculate(LoanViewModel loanVM)
    {
        AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
        if (!ModelState.IsValid) return View(loanVM);
        Loan loan = new()
        {
            AppUser=appUser,
            AppUserId=appUser.Id,
            Purpose=loanVM.Purpose,
            Amount=loanVM.Amount,
            Currency=loanVM.Currency,
            Duration=loanVM.Duration,
            Interest=loanVM.Interest,
            Guarantor=loanVM.Guarantor,
        };

        return RedirectToAction(nameof(LaonTable),loan);
    }

    public IActionResult LaonTable(Loan loan)
    {
        _context.Loans.Add(loan);
        _context.SaveChanges();
        return View(loan);
    }

    public IActionResult AcceptClick()
    {
        return View();
    }
    public IActionResult RejectClick()
    {
        return View();
    }
}
