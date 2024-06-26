using LynxWebRazor.Data;
using LynxWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LynxWebRazor.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            this._db = db;
        }
        public void OnGet(int? id)
        {
            if(id != null)
            {
                Category? obj = _db.Category.Find(id);
                Category = obj;
            }
        }
        public IActionResult OnPost()
        {
            _db.Category.Add(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
        //public IActionResult OnPost()
        //{
        //    _db.Category.Add(Category);
        //    _db.SaveChanges();
        //    return RedirectToPage("Index");
        //}
    }
}
