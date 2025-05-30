using Microsoft.EntityFrameworkCore;
using Product.API.Models;

namespace Product.API.Database
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ProductItem> ProductItems { get; set; }
    }
}
