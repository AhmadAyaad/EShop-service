using System.ComponentModel.DataAnnotations;

namespace EShop.Core.DTOS
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int? DiscountId { get; set; }
    }
}
