using EmployeeManagement.Model;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emp = _service.GetById(id);
            return emp == null ? NotFound() : Ok(emp);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Employee emp)
        {
            if (emp == null)
                return BadRequest("Employee data is null");

            _service.Add(emp);
            return Ok("Employee Added");
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee emp)
        {
            _service.Update(id, emp);
            return Ok("Employee Updated");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Employee Deleted");
        }
    }
}
