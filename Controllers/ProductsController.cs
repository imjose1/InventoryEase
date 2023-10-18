using InventoryEase.Data;
using InventoryEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryEase.Controllers
{
    public class ProductsController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(int? id ,ProductsModel product)
        {
            if (product != null)
            {
                var NewProduct = new ProductsModel
                {
                    Name = product.Name,
                    Size = product.Size,
                    Image = product.Image,
                    OrderTreshold = product.OrderTreshold,
                    OrderQuantity = product.OrderQuantity,
                    NavSectionId = product.NavSectionId,
                };
             
                _context.Products.Add(NewProduct);
                _context.SaveChanges();
                return RedirectToAction("SectionInventory","Inventory", new { id = product.NavSectionId });
            }
            else
            {
                return NotFound();
            }  
        }
        
    }
}
