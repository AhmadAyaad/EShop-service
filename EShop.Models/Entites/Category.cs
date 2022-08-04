using System.Collections.Generic;

namespace EShop.Models.Entites
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
