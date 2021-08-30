using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Queries.GetAllSkills;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllSkillsQuery = new GetAllSkillsQuery();
            var skills = await _mediator.Send(getAllSkillsQuery);
            return Ok(skills);
        }
    }
}