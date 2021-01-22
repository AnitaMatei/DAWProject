using ComicBookShop.Helper;
using ComicBookShop.Model.DTO;
using ComicBookShop.Model.Entity;
using ComicBookShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComicBookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;


        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetPageOrders(int pageNumber, int pageSize)
        {
            return Ok(orderService.GetPageOrderedByDate(GetUserFromContext(), pageNumber, pageSize));
        }

        [HttpGet("{uuid}")]
        [Authorize]
        public IActionResult GetOrderByUUID(string uuid)
        {
            return Ok(orderService.GetOrderByUUID(GetUserFromContext(), uuid));
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderRequest request)
        {
            OrderResponse response = orderService.CreateOrder(request, GetUserFromContext());
            return Created("api/order/"+response.UUID,response);
        }


        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private User GetUserFromContext() =>
            (User)HttpContext.Items["User"];
    }
}
