using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProject;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/projects?query=netCore
        [HttpGet]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Client + "," + Roles.Freelancer)]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);
            var projects = await _mediator.Send(getAllProjectsQuery);
            if(projects is null) return NotFound();
            return Ok(projects);
        }

        // GET api/projets/id
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Client + "," + Roles.Freelancer)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectQuery(id);
            var project = await _mediator.Send(query);
            if (project is null) return NotFound();
            return Ok(project);
        }

        // POST projects
        [HttpPost]
        [Authorize(Roles = Roles.Administrador + "," + Roles.Client)]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id}, command);
        }

        // PUT api/projects/id
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Client)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/projects/id
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Client)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        // POST api/projects/id/comments
        [HttpPost("{id}/comments")]
        [Authorize(Roles = Roles.Client + "," + Roles.Freelancer)]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            // 400 - return BadRequest();
            await _mediator.Send(command);
            return NoContent(); //204
        }

        // PUT api/projects/id/start
        [HttpPut("{id}/start")]
        [Authorize(Roles = Roles.Client)]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);
            await _mediator.Send(command);
            return NoContent(); //204
        }

        //PUT api/projects/id/finish
        [HttpPut("{id}/finish")]
        [Authorize(Roles = Roles.Client)]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);
            await _mediator.Send(command);
            return NoContent(); //204
        }
    }
}
