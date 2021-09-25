using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DevFreela.Application.Queries.GetAllSkills;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllSkillsQuery = new GetAllSkillsQuery(query);
            var skills = await _mediator.Send(getAllSkillsQuery);
            if(skills == null) return NotFound();
            return Ok(skills);
        }
    }
}