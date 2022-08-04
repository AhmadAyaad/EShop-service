using EShop.Core.DTOS;
using System.Threading.Tasks;

namespace EShop.Core.IService
{
    public interface IInvoiceService
    {
        Task AddNewInvoiceAsync(OrderDTO orderDTO);
    }
}
