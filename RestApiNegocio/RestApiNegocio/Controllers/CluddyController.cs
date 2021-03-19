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
    public class CuddlyController : ControllerBase
    {
        private readonly ILogger<CuddlyController> _logger;
        private ICuddly _Cuddlys;

        public CuddlyController(ILogger<CuddlyController> logger, ICuddly Cuddlys)
        {
            _logger = logger;
            _Cuddlys = Cuddlys;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult AllCuddly()
        {
            return Ok(_Cuddlys.AllCuddlys());
        }
        [HttpGet("{id}")]
        public IActionResult SingleCuddly(int id)
        {
            return Ok(_Cuddlys.SingleCuddly(id));
        }
        [HttpPost]
        public IActionResult Create([FromBody]Cuddly Cuddly)
        {
            if (Cuddly == null) return BadRequest();
            return Ok(_Cuddlys.CreateCuddly(Cuddly));
        }
        [HttpPut]
        public IActionResult Update([FromBody] Cuddly Cuddly)
        {
            return Ok(_Cuddlys.UpDateCuddly(Cuddly));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoute(int id)
        {
            return Ok(_Cuddlys.DeleteCuddly(id));
        }
    }
}
