using System;
using MediatR;
using System.Linq;
using DevFreela.API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Models.InputModels;
using DevFreela.Application.Commands.CreateUser;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public UsersController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get(string query) 
        {
            var users = _userService.GetAll(query);
            //if(users == null) return NotFound();
            return Ok(users); //200
        }

        //GET api/Users/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
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
