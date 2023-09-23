using LoanCalculator.Models;
using LoanCalculator.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoanCalculator.Controllers;
public class AccountController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    //public async Task<IActionResult> CreateRoles()
    //{
    //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
    //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
    //    return Json("ok");
    //}

    //Register-----------------------------------------------------------------------------------------------------
    public async Task<IActionResult> Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(MemberRegisterViewModel memberRegisterVM)
    {
        if (!ModelState.IsValid) return View();

        AppUser appUser = null;

        appUser = await _userManager.FindByNameAsync(memberRegisterVM.FIN);
        if (appUser is not null)
        {
            ModelState.AddModelError("FIN", "Already exist!");
            return View();
        }


        appUser = new AppUser
        {
            ActualAddress=memberRegisterVM.ActualAddress,
            SerialNumber=memberRegisterVM.SerialNumber,
            UserName=memberRegisterVM.FIN,
            FIN =memberRegisterVM.FIN,
            Name=memberRegisterVM.Name,
            Surname=memberRegisterVM.Surname,
            FatherName=memberRegisterVM.FatherName,
            RegistrationAddress=memberRegisterVM.RegistrationAddress,
            DateOfBirth=memberRegisterVM.DateOfBirth,
            PhoneNumber=memberRegisterVM.PhoneNumber,
        };


        var result = await _userManager.CreateAsync(appUser, memberRegisterVM.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        await _userManager.AddToRoleAsync(appUser, "Member");

        return RedirectToAction("login", "account");
    }

    //Log in-------------------------------------------------------------------------------------------------------
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(MemberLoginViewModel memberLoginVM)
    {
        if (!ModelState.IsValid) return View();
        AppUser user = await _userManager.FindByNameAsync(memberLoginVM.FIN);
        if (user is null)
        {
            ModelState.AddModelError("", "Username or password is false");
            return View();
        }

        var result = await _signInManager.PasswordSignInAsync(user, memberLoginVM.Password, false, false);

        if (!result.Succeeded)
        {
            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Please verify email");
                return View();

            }
            ModelState.AddModelError("", "Username or password is false");
            return View();
        }

        return RedirectToAction("index", "home");
    }
    //Log out------------------------------------------------------------------------------------------------------
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("index", "home");
    }
}