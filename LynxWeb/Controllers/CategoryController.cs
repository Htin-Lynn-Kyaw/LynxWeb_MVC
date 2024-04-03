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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name","Name and Order cannot be same.");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value.");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully Created.";
                return RedirectToAction("Index");
            }
            return View();
            
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            Category? category = _db.Category.Find(id);  //Search only PrimarKey
            //Category? category1 = _db.Category.FirstOrDefault(u => u.ID == id); //Search any
            //Category? category2 = _db.Category.Where(u=>u.ID == id).FirstOrDefault(); //Do some minipulation
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully Edited.";
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Category.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Successfully Deleted.";
            return RedirectToAction("Index");
        }
    }
}
