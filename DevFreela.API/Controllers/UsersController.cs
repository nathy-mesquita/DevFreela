using System;
using MediatR;
using System.Linq;
using DevFreela.API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Queries.GetAllUsers;
using DevFreela.Application.Queries.GetUserById;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query) 
        {
            var getAllUsersQuery = new GetAllUsersQuery(query);
            var users = await _mediator.Send(getAllUsersQuery);
            if(users == null) return NotFound();
            return Ok(users); //200
        }

        //GET api/Users/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);
            if(user == null) return NotFound();
            return Ok(user); //200
        }

        // POS api/Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            //400 - return BadRequest();
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        //PUT api/users/id/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            //Todo: Módulo de autenticação e Autorização
            return NoContent();
        }
    }
}
