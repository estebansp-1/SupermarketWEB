using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;

namespace SupermarketWEB.Pages.PayModes
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<Models.PayMode> PayMode { get; set; }

        public async Task OnGetAsync()
        {
            PayMode = await _context.PayModes.ToListAsync();
        }
    }

}
