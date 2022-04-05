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
        [HttpPost(ApiRoutes.Order.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] List<CartItem> request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(new CreatedResponse
                {
                    Errors = ModelState.Values.SelectMany(err => err.Errors.Select(errors => errors.ErrorMessage))
                });
            }
            var order = request.FirstOrDefault();
            var orderTotal = request.Sum(req => req.ItemTotal);
            var orderID = await _orderService.CreateOrderAsync(order.UserName,orderTotal);
            foreach(var req in request)
            orderID = await _orderService.CreateOrderListingAsync(orderID,req.ProductID,req.Quantity, req.ItemTotal, req.ProductPrice );
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Order.Get.ToString().Replace("{orderId}", orderID.ToString());
            return Created(locationUrl, orderID);
        }

    }
}
