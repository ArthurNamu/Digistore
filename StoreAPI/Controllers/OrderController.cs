using DataLibrary.Data;
using DataLibrary.DB;
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
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> CreateAsync([FromBody] List<CartItem> request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(new CreatedResponse
                {
                    Errors = ModelState.Values.SelectMany(err => err.Errors.Select(errors => errors.ErrorMessage))
                });
            }
            decimal totalValue = request.
            var createdID = await _orderService.CreateOrderAsync(request.ProductID,request.UserName,request.ItemTotal,request.Quantity,request.ItemTotal,request.ProductPrice );
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Product.Get.ToString().Replace("{postId}", createdID.ToString());
            request.ProductID = createdID;
            return Created(locationUrl, request);
        }

    }
}
