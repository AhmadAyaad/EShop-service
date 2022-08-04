using AutoMapper;
using EShop.Core.DTOS;
using EShop.Core.IService;
using EShop.Core.IUnitofWork;
using EShop.Models.Entites;
using System.Threading.Tasks;

namespace EShop.Core.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task AddNewInvoiceAsync(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            await _unitOfWork.InvoiceRepo.AddAsync(new Invoice { Order = order, UserId = orderDTO.UserId, Total = orderDTO.Total });
        }
    }
}
