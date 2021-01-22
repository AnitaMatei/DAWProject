using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBookShop.Context;
using ComicBookShop.Model.DTO;
using ComicBookShop.Model.Entity;
using ComicBookShop.Service;
using ComicBookShop.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComicBookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;


        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            return Ok(userService.GetProfileByUsername(GetUserFromContext().Username));
        }

        [Authorize]
        [HttpPut("editAddress")]
        public IActionResult EditAddress([FromBody] AddressEditRequest request)
        {
            userService.EditAddress(GetUserFromContext(), request);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private User GetUserFromContext() =>
            (User)HttpContext.Items["User"];
    }
}
