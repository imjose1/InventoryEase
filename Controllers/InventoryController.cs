using InventoryEase.Data;
using InventoryEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryEase.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InventoryController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            IEnumerable<NavSectionModel> sections = _context.NavSections;
            IEnumerable<ProductsModel> products = _context.Products;
            var inventoryViewModel = new InventoryViewModel()
            {
                    NavSections = sections,
                    Products = products
                };

            return View(inventoryViewModel);
        }
        //Get
        [HttpGet]
        public IActionResult SectionInventory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var allNavSections = _context.NavSections.ToList();
            var navSectionFromDb = _context.NavSections.Find(id);
            if (navSectionFromDb == null)
            {
                return NotFound();
            }

            // Retrieve associated products for the NavSection
            var productsForSection = _context.Products.Where(p => p.NavSectionId == id).ToList();

            var inventoryViewModel = new InventoryViewModel
            {
                AllNavSections= allNavSections ,
                NavSections = new List<NavSectionModel> { navSectionFromDb },
                Products = productsForSection
            };

            return View(inventoryViewModel);
        }
    }
}
