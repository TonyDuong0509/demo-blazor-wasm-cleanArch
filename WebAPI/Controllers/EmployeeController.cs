using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            this._employee = employee;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _employee.GetAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _employee.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employee)
        {
            var result = await _employee.AddAsync(employee);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employeeDto)
        {
            await _employee.UpdateAsync(employeeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employee.DeleteAsync(id);
            return Ok(result);
        }
    }
}
