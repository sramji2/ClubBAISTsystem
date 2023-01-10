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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Antonio did mention a Membership class. Think about it. 
namespace ClubBAISTsystem.Pages
{
    public class LoginModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please enter an email address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")]
        public string Email { get; set; }
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
                
                Player GolfPlayers = loginManager.UserLogin(Email, Password);

                if (Email == GolfPlayers.Email)
                {


                    if (Password == GolfPlayers.Password)
                    {
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, GolfPlayers.Email),
                        new Claim(ClaimTypes.Name, GolfPlayers.LastName),
                        new Claim(ClaimTypes.Name, GolfPlayers.FirstName),
                        new Claim(ClaimTypes.NameIdentifier, GolfPlayers.MemberNumber.ToString()),
                        new Claim(ClaimTypes.Role, GolfPlayers.Role),
                        new Claim(ClaimTypes.UserData, GolfPlayers.MembershipLevel)
                    };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, GolfPlayers.Role));

                        AuthenticationProperties authProperties = new AuthenticationProperties
                        {
                           
                            IsPersistent = false,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                            

                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), authProperties);
                        return RedirectToPage("/Welcome");
                    }
                    else if (Email != GolfPlayers.Email)
                    {
                        Message = "Invalid attempt to login";
                        return RedirectToPage("/Forbidden");
                    }
                }
            }
                Message = "Invalid attempt to login";
                return RedirectToPage("/Forbidden");

        }
        
        




        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Welcome");
        }
        public void OnGet()
        {
        }
    }
}
