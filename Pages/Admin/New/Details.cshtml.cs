using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppDJ.Data;
using ShoppDJ.Models;

namespace ShoppDJ.Pages.Admin.New
{
    public class DetailsModel : PageModel
    {
        private readonly ShoppDJ.Data.Shopingcontex _context;

        public DetailsModel(ShoppDJ.Data.Shopingcontex context)
        {
            _context = context;
        }

        public News News { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            News = await _context.News.FirstOrDefaultAsync(m => m.Id == id);

            if (News == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
