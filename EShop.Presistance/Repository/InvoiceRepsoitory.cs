using EShop.Core.IRepository;
using EShop.Models.Entites;
using EShop.Presistance.Context;

namespace EShop.Presistance.Repository
{
    public class InvoiceRepsoitory : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepsoitory(EShopDbContext context) : base(context)
        {
        }
    }
}
