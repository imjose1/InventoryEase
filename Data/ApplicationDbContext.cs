using InventoryEase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryEase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<NavSectionModel> NavSections { get; set; }
        public DbSet<ProductsModel> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure the relationship between ProductModel and NavSection
            modelBuilder.Entity<ProductsModel>()
                .HasOne(p => p.NavSection)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.NavSectionId);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

    }
}