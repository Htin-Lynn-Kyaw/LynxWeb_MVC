using LynxWebRazor.Data;
using LynxWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LynxWebRazor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            this._db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                Category? obj = _db.Category.Find(id);
                Category = obj;
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Category.Remove(Category);
                _db.SaveChanges();
                //TempData["success"] = "Successfully Edited.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
