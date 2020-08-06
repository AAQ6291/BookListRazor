using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.Products
{
    public class indexModel : PageModel
    {
        private readonly SQLiteDBContext _db;

        public indexModel(SQLiteDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Prd> Prds { get; set; }

        public async Task OnGet()
        {
            Prds = await _db.Products.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var prd = await _db.Products.FindAsync(id);
            if(prd == null)
            {
                return NotFound();
            }
            _db.Products.Remove(prd);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}