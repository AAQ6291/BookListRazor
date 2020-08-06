using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookListRazor.Model;

namespace BookListRazor.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly SQLiteDBContext _db;

        public CreateModel(SQLiteDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Prd Prds { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Products.AddAsync(Prds);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}