using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService) 
        => _skillService = skillService;

        [HttpGet]
        public IActionResult Get()
        {
            var skills = _skillService.GetAll();
            return Ok(skills);
        }
    }
}