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
        public Models.User Users { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Verifica que se estén recibiendo datos
            if (string.IsNullOrEmpty(Users.Email) || string.IsNullOrEmpty(Users.Password))
            {
                ErrorMessage = "Correo o contraseña vacíos.";
                return Page();
            }

            // Valida el usuario en la BD
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == Users.Email && u.Password == Users.Password);

            if (user == null)
            {
                ErrorMessage = "Correo o contraseña inválidos.";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", principal);

            return Redirect("/Index");
        }
    }
}