using EShop.Core.DTOS;
using EShop.Core.IService;
using EShop.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EShop.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;
        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);
            try
            {
                await _productService.AddNewProductAsync(productDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Add New Product");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while adding new product.");
            }
        }
        [HttpPost("filter-products-by-categories-ids")]
        public async Task<IActionResult> FilterProductsByCategoriesIds(FilterProductDTO filterProductDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);
            try
            {
                var productsDTOS = await _productService.FilterProductsByCategoriesIds(filterProductDTO.CategoriesIds, filterProductDTO.PageIndex, filterProductDTO.PageSize);
                return Ok(productsDTOS);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Filter Products By Categories Ids");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while filtering products.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPaginatedProducts([FromQuery] PaginationFilter paginationFilter)
        {
            try
            {
                return Ok(await _productService.GetPaginatedProductsAsync(paginationFilter.PageNumber, paginationFilter.PageSize));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Get Paginated Products");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while getting paginated products.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var productDTOResponse = await _productService.GetProductAsync(id);
                if (productDTOResponse.Status != ResponseStatus.Succeeded)
                    return BadRequest(productDTOResponse.GetMessages());
                return Ok(productDTOResponse.Data);
            }
            catch (Exception)
            {
                //TODO : Log exception
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Exception has been thrown while getting  product with id:{id}");
            }
        }
        [HttpPost("products-by-ids")]
        public async Task<IActionResult> GetProductsWithDiscountByIds(List<int> productsIds)
        {
            try
            {
                var productDTOs = await _productService.GetProductsWithDiscountByIdsAsync(productsIds);
                return Ok(productDTOs);
            }
            catch (Exception)
            {
                //TODO : Log exception
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Exception has been thrown while getting  products.");
            }
        }
    }
}
