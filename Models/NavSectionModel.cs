using System.ComponentModel.DataAnnotations;


namespace InventoryEase.Models
{
    public class NavSectionModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public List<ProductsModel>? Products { get; set; }
    }
}
