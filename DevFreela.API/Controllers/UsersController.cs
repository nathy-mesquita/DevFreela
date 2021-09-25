using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Queries.GetAllUsers;
using DevFreela.Application.Queries.GetUserById;
using DevFreela.Application.Commands.LoginUser;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles= Roles.Administrador)]
        public async Task<IActionResult> Get(string query) 
        {
            var getAllUsersQuery = new GetAllUsersQuery(query);
            var users = await _mediator.Send(getAllUsersQuery);
            if(users is null) return NotFound();
            return Ok(users); //200
        }

        //GET api/Users/id
        [HttpGet("{id}")]
        [Authorize(Roles= Roles.Administrador)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);
            if(user is null) return NotFound();
            return Ok(user); //200
        }

        // POS api/Users
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        //PUT api/users/id/login
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);
            if (loginUserViewModel is null) return BadRequest();
            return Ok(loginUserViewModel);
        }
    }
}
