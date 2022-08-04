using System;

namespace EShop.Models.Entites
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; }
    }
}
