using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppDJ.Data;
using ShoppDJ.Models;

namespace ShoppDJ.Pages.Admin.CategoryToprpduct
{
    public class EditModel : PageModel
    {
        private readonly ShoppDJ.Data.Shopingcontex _context;

        public EditModel(ShoppDJ.Data.Shopingcontex context)
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
           ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Id");
           ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CategoryToproduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryToproductExists(CategoryToproduct.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryToproductExists(int id)
        {
            return _context.CategoryToproducts.Any(e => e.ProductId == id);
        }
    }
}
