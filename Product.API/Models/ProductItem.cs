using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.API.Models
{
    public class ProductItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

        public int AvailableInStock { get; set; }

        public int ThresholdLevel { get; set; }

    }
}
