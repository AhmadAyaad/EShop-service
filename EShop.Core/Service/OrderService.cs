using AutoMapper;
using EShop.Core.DTOS;
using EShop.Core.IService;
using EShop.Core.IUnitofWork;
using EShop.Identity.IService;
using EShop.Models.Entites;
using EShop.Shared;
using System.Threading.Tasks;

namespace EShop.Core.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IInvoiceService _invoiceService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper,
                            IAccountService accountService, IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountService = accountService;
            _invoiceService = invoiceService;
        }
        public async Task<Response> PlaceOrderAsync(OrderDTO orderDTO)
        {
            if (!await _accountService.IsExistingUserAsync(orderDTO.UserId))
                return new Response(ResponseStatus.BadRequest, "Invalid user Id");
            var newOrder = _mapper.Map<Order>(orderDTO);
            await _unitOfWork.OrderRepo.AddAsync(newOrder);
            await _invoiceService.AddNewInvoiceAsync(orderDTO);
            await _unitOfWork.SaveChangesAsync();
            return new Response();
        }
    }
}
