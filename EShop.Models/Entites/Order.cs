using System.Collections.Generic;

namespace EShop.Models.Entites
{
    public class Order : BaseEntity
    {
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
