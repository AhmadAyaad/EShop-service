namespace EShop.Models.Entites
{
    public class Discount : BaseEntity
    {
        public float DiscountPercentage { get; set; }
        public int NumberOfPieces { get; set; }
        public bool IsActive { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
