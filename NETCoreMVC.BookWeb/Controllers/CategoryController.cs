using Microsoft.AspNetCore.Mvc;
using NETCoreMVC.BookWeb.Data;
using NETCoreMVC.BookWeb.Models;

namespace NETCoreMVC.BookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _applicationDbContext.Category;
            return View(categoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category newCategory)
        {
            if (newCategory.Name == newCategory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and DisplayOrder cannot be same");
            }
            if (ModelState.IsValid)
            {
                _applicationDbContext.Category.Add(newCategory);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id== null || id==0)
            {
                return NotFound();
            }
            var category = _applicationDbContext.Category.Find(id);
            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category newCategory)
        {
            if (newCategory.Name == newCategory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and DisplayOrder cannot be same");
            }
            if (ModelState.IsValid)
            {
                _applicationDbContext.Category.Update(newCategory);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _applicationDbContext.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAction(int? id)
        {

            var category = _applicationDbContext.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _applicationDbContext.Remove(category);
            _applicationDbContext.SaveChanges();
                TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
