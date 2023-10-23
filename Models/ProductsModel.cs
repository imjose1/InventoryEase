using System.ComponentModel.DataAnnotations;

namespace InventoryEase.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }
        [Required]public string? Name { get; set; }
        [Required]public string? Size { get; set; }
        [Required]public string? Image { get; set; }
        [Required] public int OrderTreshold { get; set; }
        [Required]public int OrderQuantity { get; set; }
        [Required]public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public int NavSectionId { get; set; }
        public NavSectionModel? NavSection { get; set; }
    }
}
