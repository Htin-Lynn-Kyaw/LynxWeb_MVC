using LynxWebRazor.Data;
using LynxWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LynxWebRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category>? CategoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            this._db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Category.ToList();
        }
    }
}
