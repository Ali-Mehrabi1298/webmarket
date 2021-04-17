using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppDJ.Data;
using ShoppDJ.Models;

namespace ShoppDJ.Pages.Admin.AddToproduct
{
    public class Ediit2Model : PageModel
    {
        private readonly ShoppDJ.Data.Shopingcontex _context;

        public Ediit2Model(ShoppDJ.Data.Shopingcontex context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public AddEditProductViewModel Productse { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
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

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }




            return RedirectToPage("./CreateCTP");
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.Id == id);
        }
    }
}
