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
    public class CreateModel : PageModel
    {
        private readonly ShoppDJ.Data.Shopingcontex _context;

        public CreateModel(ShoppDJ.Data.Shopingcontex context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Id");
        ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id");
          
            return Page();
        }

        [BindProperty]
        public CategoryToproduct CategoryToproduct { get; set; }
        [BindProperty]
        public IList<Product> Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CategoryToproducts.Add(CategoryToproduct);
            _context.products.ToList();

            await _context.SaveChangesAsync();
           
         
            return RedirectToPage("./Index");
        }
    }
}
