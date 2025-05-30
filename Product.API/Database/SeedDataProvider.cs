using Product.API.Models;

namespace Product.API.Database
{
    public class SeedDataProvider
    {
        public static void Initialize(ProductContext context)
        {
            if (!context.ProductItems.Any())
            {
                var productItem = new List<ProductItem>
                {
                    new ProductItem
                    {
                        Name = "Shirt",
                        Description = "This is red color shirt",
                        Color = "Red",
                        Price = 200,
                        AvailableInStock = 200,
                        ThresholdLevel = 10
                    },
                    new ProductItem
                    {
                        Name = "Pant",
                        Description = "This is red color pant",
                        Color = "Red",
                        Price = 200,
                        AvailableInStock = 200,
                        ThresholdLevel = 10
                    },
                    new ProductItem
                    {
                        Name = "Cap",
                        Description = "This is red color cap",
                        Color = "Red",
                        Price = 100,
                        AvailableInStock = 100,
                        ThresholdLevel = 5
                    },
                };

                context.ProductItems.AddRange(productItem);
                context.SaveChanges();
            }
        }
    }
}
