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
    public class IndexModel : PageModel
    {
        private readonly ShoppDJ.Data.Shopingcontex _context;

        public IndexModel(ShoppDJ.Data.Shopingcontex context)
        {
            _context = context;
        }

        public IList<CategoryToproduct> CategoryToproduct { get;set; }

        public async Task OnGetAsync()
        {
            CategoryToproduct = await _context.CategoryToproducts
                .Include(c => c.Category)
                .Include(c => c.product).ToListAsync();
        }
    }
}
