using System;
using System.Linq;
using DevFreela.API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;

        public ProjectsController(IOptions<OpeningTimeOption> option)
        {
            _option = option.Value;
        }

        // GET: api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            //Buscar todos ou filtrar
            return Ok();
        }

        // GET api/projets/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Buscar o projeto
            //return NotFound();
            return Ok();
        }

        // POST projects
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title.Length > 50)
            {
                return BadRequest();
            }
            //cadastrar o projeto

            return CreatedAtAction(nameof(GetById), new { id = createProject.Id}, createProject);
        }

        // PUT api/projects/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }
            //Atualizar o projeto

            return NoContent();
        }

        // DELETE api/projects/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Buscar, se não existir, retorna NotFound();

            //Remover (permanente ou alterar uma flag(Ativo/inativo)) 
            return NoContent();
        }

        // POST api/projects/id/comments
        [HttpPost("{id}/comments")]
        public IActionResult PosComment(int id, [FromBody] CreateCommentModel createComment)
        {
            // 400 - return BadRequest();
            return NoContent(); //204
        }

        // PUT api/projects/id/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent(); //204
        }

        //PUT api/projects/id/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent(); //204
        }

    }
}
