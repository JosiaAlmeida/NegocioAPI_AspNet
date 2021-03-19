using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    }
}
