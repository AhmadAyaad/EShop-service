namespace EShop.Models.Entites
{
    public class Invoice : BaseEntity
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public decimal Total { get; set; }
    }
}
