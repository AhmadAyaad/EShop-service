using System.Collections.Generic;

namespace EShop.Core.DTOS
{
    public class OrderDTO
    {
        public List<OrderItemDTO> OrderItems { get; set; }
        public string UserId { get; set; }
        public decimal Total { get; set; }
    }
}
