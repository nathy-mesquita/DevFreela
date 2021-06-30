using System;
using System.Linq;
using DevFreela.API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public UsersController(ExampleClass exampleClass)
        {
            exampleClass.Name = "Updated at UserController";
        }

        [HttpGet]
        public IActionResult Get(string query) 
        {
            //Buscar Todos ou Filtrar
            // return NotFound();
            return Ok(); //200
        }

        //GET api/Users/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           //404- return NotFound();
            return Ok(); //200
        }

        // POS api/Users
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createUser)
        {
            //400 - return BadRequest();

            //O que ele espera? -Nome da rota, Qual parâmetro ele recebe? - id, Qual vai ser o retorno? -Objeto cadastrado (CreateUser)
            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUser);
        }

        //PUT api/users/id/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }
       
    }
}
