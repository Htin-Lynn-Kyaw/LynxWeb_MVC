using LynxWeb.Data;
using LynxWeb.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LynxWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategory = _db.Category.ToList();
            return View(objCategory);
        }
    }
}
