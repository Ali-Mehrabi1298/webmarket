using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppDJ.Data;
using ShoppDJ.Models;

namespace ShoppDJ.Pages.Admin.category
{
    public class IndexModel : PageModel
    {
        private readonly ShoppDJ.Data.Shopingcontex _context;

        public IndexModel(ShoppDJ.Data.Shopingcontex context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.categories.ToListAsync();
        }
    }
}
