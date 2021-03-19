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
    public class FoodController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;
        private IFood _Foods;

        public FoodController(ILogger<FoodController> logger, IFood Foods)
        {
            _logger = logger;
            _Foods = Foods;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult AllFood()
        {
            return Ok(_Foods.AllFoods());
        }
        [HttpGet("{id}")]
        public IActionResult SingleFood(int id)
        {
            return Ok(_Foods.SingleFood(id));
        }
        [HttpPost]
        public IActionResult Create([FromBody]Food Food)
        {
            if (Food == null) return BadRequest();
            return Ok(_Foods.CreateFood(Food));
        }
        [HttpPut]
        public IActionResult Update([FromBody] Food Food)
        {
            return Ok(_Foods.UpDateFood(Food));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoute(int id)
        {
            return Ok(_Foods.DeleteFood(id));
        }
    }
}
