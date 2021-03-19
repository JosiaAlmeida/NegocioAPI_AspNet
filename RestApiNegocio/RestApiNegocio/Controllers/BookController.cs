using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApiNegocio.Models;
using RestApiNegocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApiNegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBook _Books;

        public BookController(ILogger<BookController> logger, IBook books)
        {
            _logger = logger;
            _Books = books;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult AllBook()
        {
            return Ok(_Books.AllBooks());
        }
        [HttpGet("{id}")]
        public IActionResult SingleBook(int id)
        {
            return Ok(_Books.SingleBook(id));
        }
        [HttpPost]
        public IActionResult Create([FromBody]Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_Books.CreateBook(book));
        }
        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            return Ok(_Books.UpDateBook(book));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoute(int id)
        {
            return Ok(_Books.DeleteBook(id));
        }
    }
}
