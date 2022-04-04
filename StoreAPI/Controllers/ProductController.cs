using DataLibrary.Data;
using DataLibrary.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Contracts.V1;
using StoreAPI.Contracts.V1.Response;
using StoreAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost(ApiRoutes.Product.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] ProductModel request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(new CreatedResponse
                {
                    Errors = ModelState.Values.SelectMany(err => err.Errors.Select(errors => errors.ErrorMessage))
                });
            }
            var createdID = await _productService.CreateProductAsync(request.ProductName,request.CategoryID,request.ProductDescription,request.ImagePath,request.ProductPrice);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Product.Get.ToString().Replace("{postId}", createdID.ToString());
            request.ProductID = createdID;
            return Created(locationUrl, request);
        }
        [HttpGet(ApiRoutes.Product.Get)]
        public async Task<IActionResult> Get([FromRoute] string productID)
        {
            var product = await _productService.GetProductAsync(productID);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
        [HttpGet(ApiRoutes.Product.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            Task.Delay(5000);
            return Ok(await _productService.GetAllProductsAsync());
        }
    }
}
