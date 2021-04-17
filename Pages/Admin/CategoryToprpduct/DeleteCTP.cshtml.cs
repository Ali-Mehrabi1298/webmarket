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
    public class DeleteModel : PageModel
    {
        private readonly ShoppDJ.Data.Shopingcontex _context;

        public DeleteModel(ShoppDJ.Data.Shopingcontex context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryToproduct = await _context.CategoryToproducts.FindAsync(id);

            if (CategoryToproduct != null)
            {
                _context.CategoryToproducts.Remove(CategoryToproduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
