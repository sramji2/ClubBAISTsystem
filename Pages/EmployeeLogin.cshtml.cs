using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClubBAISTsystem.Model.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubBAISTsystem.Pages
{
    public class EmployeeLoginModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please enter your Employee Number")]
        [RegularExpression(@"^[+]?\d*$")]
        public string EmployeeNumber { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please enter a password")]
        [RegularExpression(@"^.{6,}$", ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }
        [BindProperty]
        public string Role { get; set; }


        public async Task<IActionResult> OnPostSearch()
        {

            if (ModelState.IsValid)
            {

                CBS loginManager = new CBS();
               
                Employee ClubEmployees = loginManager.EmployeeLogin(EmployeeNumber, Password);

                if (EmployeeNumber == ClubEmployees.EmployeeNumber)
                {


                    if (Password == ClubEmployees.Password)
                    {
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, ClubEmployees.Email),
                        new Claim(ClaimTypes.Name, ClubEmployees.EmployeeName),
                        new Claim(ClaimTypes.NameIdentifier, ClubEmployees.EmployeeNumber.ToString()),
                        new Claim(ClaimTypes.Role, ClubEmployees.Role),
                    };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, ClubEmployees.Role));

                        AuthenticationProperties authProperties = new AuthenticationProperties
                        {

                            IsPersistent = false,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),

                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), authProperties);
                        return RedirectToPage("/Welcome");
                    }
                }
            }
            Message = "Invalid attempt to login";
            return RedirectToPage("/Forbidden");

        }
        public void OnGet()
        {
        }
    }
}
