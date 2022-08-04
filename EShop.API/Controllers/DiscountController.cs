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
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddNewDiscount(DiscountDTO discountDTO)
        {
            try
            {
                var response = await _discountService.AddNewDiscountAsync(discountDTO);
                if (response.Status != ResponseStatus.Succeeded)
                    return BadRequest(response.GetMessages());
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                //TODO : Log exception
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while adding new discount.");
            }
        }
        [AllowAnonymous]
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetDiscount(int productId)
        {
            try
            {
                var discountDTO = await _discountService.GetDiscountByProductIdAsync(productId);
                return Ok(discountDTO);
            }
            catch (Exception ex)
            {
                //TODO : Log exception
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while adding new discount.");
            }
        }

    }
}
