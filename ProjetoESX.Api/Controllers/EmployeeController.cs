using Microsoft.AspNetCore.Mvc;
using ProjetoESX.Domain.Commands.Inputs;
using ProjetoESX.Domain.Commands.Output;
using ProjetoESX.Domain.Handlers;
using ProjetoESX.Shared.Commands;

namespace ProjetoESX.Api.Controllers
{        
    public class EmployeeController : Controller
    {
        private readonly EmployeeHandler _handler;

        public EmployeeController(EmployeeHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Employee API";
        }

        [HttpPost]
        [Route("v1/employee")]
        public ICommandResult Post([FromBody]EmployeeCommand command)
        {
            var result = (CommandResult)_handler.Handle(command);
            return result;
        }
    }
}