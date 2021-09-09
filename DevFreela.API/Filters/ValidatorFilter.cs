using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DevFreela.API.Filters
{
    public class ValidatorFilter : IActionFilter
    {
        /// <summary>
        /// Método executado depois da requisição
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        /// <summary>
        /// Método executado antes da requisição (Action)
        /// </summary>
        /// <param name="context">Model State</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var messages = context.ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                context.Result = new BadRequestObjectResult(messages);
            }
        }
    }
}