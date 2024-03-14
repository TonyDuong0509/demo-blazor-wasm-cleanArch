using ApplicationLayer.Commands.EmployeeCommand;
using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _mediator.Send(new GetEmployeeListQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employee)
        {
            var result = await _mediator.Send(new CreateEmployeeCommand { employee = employee });
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employeeDto)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand { Employee = employeeDto });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand { Id = id });
            return Ok(result);
        }
    }
}
