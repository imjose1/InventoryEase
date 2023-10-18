namespace InventoryEase.Models
{
    public class InventoryViewModel
    {
        public IEnumerable<NavSectionModel> NavSections { get; set; }
        public IEnumerable<ProductsModel> Products { get; set; }
        public List<NavSectionModel> AllNavSections { get; set; }
    }
}
