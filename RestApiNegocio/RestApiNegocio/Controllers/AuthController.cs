using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApiNegocio.Models;
using RestApiNegocio.Repositorio;
using RestApiNegocio.Repositorio.Implementação;
using RestApiNegocio.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApiNegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // GET: api/<AuthController>
        public IUser interfac;

        private readonly ILogger<AuthController> _logger;
        public AuthController(ILogger<AuthController> logger ,IUser interfac)
        {
            _logger= logger;
            this.interfac = interfac;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario user)
        {
            var User = interfac.UserLast(user);
            if (User == null)
                return NotFound(new { message = "Usuario ou senha incorreta" });
            var token = TokenServices.GenerateToken(User);
            return new
            {
                User = User,
                token = token
            };
        }
        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Signup([FromBody] Usuario user)
        {
            var User = interfac.Newuser(user);
            if (User == null)
                return NotFound(new { message = "Usuario ou senha incorreta" });
            var token = TokenServices.GenerateToken(User);
            return new
            {
                User = User,
                token = token
            };
        }
        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => string.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionario";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";
    }
}
