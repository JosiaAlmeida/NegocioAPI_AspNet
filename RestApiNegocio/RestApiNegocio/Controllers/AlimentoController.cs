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
    public class AlimentoController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private ICuddly _Cuddly;

        public AlimentoController(ILogger<BookController> logger, ICuddly Cuddly)
        {
            _logger = logger;
            _Cuddly = Cuddly;
        }

        // GET: api/<AlimentoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_Cuddly.All());
        }

        // GET api/<AlimentoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlimentoController>
        [HttpPost]
        public IActionResult Post([FromBody] Cuddly Cuddly)
        {
            if (Cuddly == null) return BadRequest();
            return Ok(_Cuddly.Create(Cuddly));
        }

        // PUT api/<AlimentoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlimentoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
