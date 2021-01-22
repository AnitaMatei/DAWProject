using ComicBookShop.Model.DTO;
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
    public class ComicBookController : ControllerBase
    {
        private readonly IComicBookService comicBookService;


        public ComicBookController(IComicBookService comicBookService)
        {
            this.comicBookService = comicBookService;
        }

        [HttpGet]
        public IActionResult GetPageByName(string? name, int pageSize, int pageNumber)
        {
            if (name == null)
                return Ok(comicBookService.GetPage(pageNumber, pageSize));
            return Ok(comicBookService.GetPageByName(name,pageNumber, pageSize));
        }

        [HttpGet("orderBy")]
        public IActionResult GetPageOrderedByPrice(string order, int pageSize, int pageNumber)
        {
            if (order == null)
                return BadRequest();

            if (order.Equals("price"))
                return Ok(comicBookService.GetPageOrderedByPrice(pageNumber, pageSize));
            else if (order.Equals("date"))
                return Ok(comicBookService.GetPageOrderedByDate(pageNumber, pageSize));
            else return BadRequest();
        }

        [HttpGet("{title}")]
        public IActionResult GetByTitle(string title)
        {
            if (title == null)
                return BadRequest();

            return Ok(comicBookService.GetByTitle(title));
        }

    }
}
