using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            try
            {
                Products = await _context.Products
                    .Include(p => p.Category)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                Console.WriteLine($"Error loading products: {ex.Message}");
            }
        }
    }
}