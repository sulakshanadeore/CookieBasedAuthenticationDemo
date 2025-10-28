﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookieBasedAuthenticationDemo.Controllers
{
    public class AccountController : Controller
    {

       
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {

            if (username=="jack" && password=="123")
            {
                var claims = new List<Claim> { 
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role,"Admin")
                
                };
                var identity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal=new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
                return RedirectToAction("Index", "Home"); 
            }
            ViewBag.Message = "Invalid username/password";
            return View();
        }

        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public ActionResult NotAvailable()
        {

            return View();
        }
    }
}
