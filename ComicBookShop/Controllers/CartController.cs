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
    public class CartController : ControllerBase
    {
        private readonly ICartItemService cartItemService;


        public CartController(ICartItemService cartItemService)
        {
            this.cartItemService = cartItemService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetPage(int pageNumber, int pageSize)
        {
            return Ok(cartItemService.GetPage(GetUserFromContext(), pageNumber, pageSize));
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddCartItem([FromBody] CartItemRequest request)
        {
            cartItemService.AddCartItem(GetUserFromContext(), request.Title);
            return Ok();
        }
        [HttpPut("incQuantity")]
        [Authorize]
        public IActionResult IncreaseCartItemQuantity([FromBody] CartItemRequest request)
        {
            cartItemService.IncreaseQuantity(GetUserFromContext(), request.Title);
            return Ok();
        }

        [HttpPut("decQuantity")]
        [Authorize]
        public IActionResult DecreaseCartItemQuantity([FromBody] CartItemRequest request)
        {
            cartItemService.ReduceQuantity(GetUserFromContext(), request.Title);
            return Ok();
        }
        [HttpDelete("{title}")]
        [Authorize]
        public IActionResult RemoveCartItem(string title)
        {
            cartItemService.RemoveCartItem(GetUserFromContext(), title);
            return Ok();

        }
        private User GetUserFromContext() =>
            (User)HttpContext.Items["User"];
    }
}