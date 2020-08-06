using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    [Route("api/Prduct")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly SQLiteDBContext _db;

        public ProductController(SQLiteDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Products.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var prdFromDb = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);
            if (prdFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Products.Remove(prdFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
