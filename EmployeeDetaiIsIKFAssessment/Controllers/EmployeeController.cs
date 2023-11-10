using EmployeeDetaiIsIKFAssessment.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace EmployeeDetaiIsIKFAssessment.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeBLL employeeBLL;

        public EmployeeController(EmployeeBLL employeeBLL)
        {
            this.employeeBLL = employeeBLL;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            List<Employee> employees = employeeBLL.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            Employee employees = employeeBLL.GetEmployees(id);
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeBLL.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee); ;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = employeeBLL.GetEmployees().FirstOrDefault(e => e.Id == id);

                if (existingEmployee == null)
                {
                    return NotFound("Employee not found");
                }

                existingEmployee.Name = employee.Name;
                existingEmployee.DOB = employee.DOB;
                existingEmployee.Designation = employee.Designation;
                existingEmployee.Skills = employee.Skills;

                employeeBLL.UpdateEmployee(existingEmployee);

                return Ok("Employee updated successfully");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var existingEmployee = employeeBLL.GetEmployees().FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
            {
                return NotFound("Employee not found");
            }

            employeeBLL.DeleteEmployee(id);

            return Ok("Employee deleted successfully");
        }
    }

}
