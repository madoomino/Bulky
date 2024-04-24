using Bulky.DataAccess;
using Bulky.DataAccess.Repository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    // what is the point of using ICategoryRepository instead of AppliactionDbContext?
    // ICategoryRepository is an interface that has all the methods that we need to interact with the database
    // ok but what is the meaning of ICategoryReopsitory db?
    // ICategoryRepository db is a private readonly field that is used to access the methods in the ICategoryRepository interface
    // what is the point of using _categoryRepo?
    // _categoryRepo is an instance of the ICategoryRepository interface that is used to access the methods in the ICategoryRepository interface
    // so what is the benefit of ApplicationDbContext now?
    // 
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display Order cannot be the same");
            }

            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["created"] = "Category Saved Successfully";
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _categoryRepo.Get(obj => obj.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["edited"] = "Category Updated Successfully";
                return RedirectToAction("Index");

            }
            return View(obj);
        }
        public IActionResult Delete(Category obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            TempData["deleted"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
