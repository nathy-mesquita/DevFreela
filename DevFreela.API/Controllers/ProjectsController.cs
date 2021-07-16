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
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService) 
        => _projectService = projectService;

        // GET: api/projects?query=netCore
        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);
            return Ok(projects);
        }

        // GET api/projets/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        // POST projects
        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if (inputModel.Title.Length > 50)
            {
                return BadRequest();
            }
            var id = _projectService.Create(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id}, inputModel);
        }

        // PUT api/projects/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
            {
                return BadRequest();
            }
            _projectService.Update(inputModel);
            return NoContent();
        }

        // DELETE api/projects/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return NoContent();
        }

        // POST api/projects/id/comments
        [HttpPost("{id}/comments")]
        public IActionResult PosComment(int id, [FromBody] CreateCommentInputModel inputModel)
        {
            // 400 - return BadRequest();
            _projectService.CreateComment(inputModel);
            return NoContent(); //204
        }

        // PUT api/projects/id/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return NoContent(); //204
        }

        //PUT api/projects/id/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent(); //204
        }
    }
}
