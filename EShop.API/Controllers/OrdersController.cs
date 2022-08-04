using EShop.Core.DTOS;
using EShop.Core.IService;
using EShop.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EShop.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder(OrderDTO orderDTO)
        {
            try
            {
                var response = await _orderService.PlaceOrderAsync(orderDTO);
                if (response.Status != ResponseStatus.Succeeded)
                    return BadRequest(response.GetMessages());
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                //TODO : Log exception
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while placing new order.");
            }
        }

    }
}
