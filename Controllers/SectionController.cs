using InventoryEase.Data;
using InventoryEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryEase.Controllers
{
    public class SectionController : Controller
    {
        public readonly ApplicationDbContext _context;
        public SectionController(ApplicationDbContext db)
        {
            _context = db;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NavSectionModel obj)
        {
            
            if (ModelState.IsValid) {
                _context.NavSections.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Section Created successfully";
                return RedirectToAction("Index", "Inventory");
            }
          
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var navSectionFromDb = _context.NavSections.Find(id);
            if (navSectionFromDb == null)
            {
                return NotFound();
            }
            return View(navSectionFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NavSectionModel obj)
        {

            if (ModelState.IsValid)
            {
                _context.NavSections.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Section updated successfully";
                return RedirectToAction("Index", "Inventory");
            }

            return View(obj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var navSectionFromDb = _context.NavSections.Find(id);
            if (navSectionFromDb == null)
            {
                return NotFound();
            }
            return View(navSectionFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.NavSections.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
          
            _context.NavSections.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Section deleted successfully";
            return RedirectToAction("Index", "Inventory");
                     
        }
       
      

    }
}
