using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppDJ.Data;
using ShoppDJ.Models;

namespace ShoppDJ.Pages.Admin.CategoryToprpduct
{
    public class DetailsModel : PageModel
    {
        private readonly ShoppDJ.Data.Shopingcontex _context;

        public DetailsModel(ShoppDJ.Data.Shopingcontex context)
        {
            _context = context;
        }

        public CategoryToproduct CategoryToproduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryToproduct = await _context.CategoryToproducts
                .Include(c => c.Category)
                .Include(c => c.product).FirstOrDefaultAsync(m => m.ProductId == id);

            if (CategoryToproduct == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
