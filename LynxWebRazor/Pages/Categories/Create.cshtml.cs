using LynxWebRazor.Data;
using LynxWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LynxWebRazor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            this._db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Category obj)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
