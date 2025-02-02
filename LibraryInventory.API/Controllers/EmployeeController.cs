using LibraryInventory.Model.Models.Person;
using LibraryInventory.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace LibraryInventory.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult> SearchEmployees()
        {
            return Ok();
        }

        [HttpGet]
        [Route("getEmployee/{employeeId}")]
        public async Task<ActionResult> GetEmployee(string employeeId)
        {
            var employee = await _employeeService.GetEmployeeAsync(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // Admin level endpoints 

        [HttpPost]
        [Route("addEmployee")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> AddEmployee([FromBody] Employee newEmployee)
        {
            var employee = await _employeeService.AddEmployeeAsync(newEmployee);
            return Ok(employee);
        }

        [HttpPut]
        [Route("updateEmployee")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }

        [HttpPut]
        [Route("inactivateEmployee/{id}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> InactivateEmployee(string id)
        {
            if (await _employeeService.EmployeeExistsAsync(id) == false)
            {
                return NotFound();
            }

            await _employeeService.InactivateEmployeeAsync(id);
            return NoContent();
        }

        [HttpDelete]
        [Route("deleteEmployee/{id}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> DeleteEmployee(string id)
        {
            if (await _employeeService.EmployeeExistsAsync(id) == false)
            {
                return NotFound();
            }

            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
