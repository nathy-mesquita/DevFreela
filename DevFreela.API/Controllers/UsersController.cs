using System;
using System.Linq;
using DevFreela.API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Models.InputModels;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) 
        => _userService = userService;

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
        public IActionResult Post([FromBody] NewUserInputModel inputModel)
        {
            var id = _userService.Create(inputModel);
            //400 - return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        //PUT api/users/id/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }
    }
}
