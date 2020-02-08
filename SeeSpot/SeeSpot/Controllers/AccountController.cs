using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeeSpot.Models;

namespace SeeSpot.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserMgr { get; }
        private SignInManager<ApplicationUser> SignInMgr { get; }
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;

        }
        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        public async Task<IActionResult> Login()
        {
            var result = await SignInMgr.PasswordSignInAsync("TestUser", "Test123!", false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "result is: " + result.ToString();
            }
            return View();
        }        
        
        
        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User already registered";

                ApplicationUser user = await UserMgr.FindByNameAsync("TestUser");
                if (user == null)
                {
                    user = new ApplicationUser();
                    user.UserName = "TestUser";
                    user.Email = "TestUser@Test.com";
                    user.FirstName = "John";
                    
                    IdentityResult result = await UserMgr.CreateAsync(user, "Test123!");
                    ViewBag.Message = "User was created";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }

    }
}