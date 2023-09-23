using LoanCalculator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoanCalculator.Context;
public class LoanCalculatorDbContext: IdentityDbContext
{
	public LoanCalculatorDbContext(DbContextOptions<LoanCalculatorDbContext> options) : base(options) { }

    public DbSet<AppUser> AppUsers => this.Set<AppUser>();
    public DbSet<Loan> Loans => this.Set<Loan>();
}