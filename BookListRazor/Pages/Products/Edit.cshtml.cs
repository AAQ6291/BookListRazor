using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.Products
{
    public class EditModel : PageModel
    {
        private SQLiteDBContext _db;

        public EditModel(SQLiteDBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Prd Prd { get; set; }

        public async Task OnGet(int id)
        {
            Prd = await _db.Products.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(int id) {
            if (ModelState.IsValid)
            {
                var PrdFromDb = await _db.Products.FindAsync(id);
                PrdFromDb.Id = Prd.Id;
                PrdFromDb.Name = Prd.Name;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            } else
            {
                return RedirectToPage();
            }
        }
    }
}