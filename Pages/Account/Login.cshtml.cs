using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace SupermarketWEB.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SupermarketContext _context;

        public LoginModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.User User { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult>OnPostAnysec()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Email && u.Password == User.Password);

        if(user == null)
            {
                ErrorMessage = "Invalid email or password";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identify = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimsprincipal = new ClaimsPrincipal(identify);

            await HttpContext.SignInAsync("MyCookieAuth", claimsprincipal);

            return Redirect("/Index");
            }
        }   
}
