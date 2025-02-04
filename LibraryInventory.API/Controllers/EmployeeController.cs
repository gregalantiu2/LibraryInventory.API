﻿using LibraryInventory.API.Extensions;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;
using LibraryInventory.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
                return NotFound(MessageHelper<Employee>.NotFound(employeeId));
            }

            return Ok(employee);
        }

        [HttpGet]
        [Route("getEmployeeContactInfo/{employeeId}")]
        public async Task<ActionResult> GetEmployeeContactInfo(string employeeId)
        {
            var contactInfo = await _employeeService.GetEmployeeContactInfo(employeeId);

            if (contactInfo == null)
            {
                return NotFound(MessageHelper<ContactInfo>.NotFound(employeeId));
            }

            return Ok(contactInfo);
        }

        // Admin level endpoints 

        [HttpPost]
        [Route("addEmployee")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> AddEmployee([FromBody] Employee newEmployee)
        {
            if (newEmployee == null)
            {
                return BadRequest(MessageHelper<Employee>.ObjectNull());
            }

            var employee = await _employeeService.AddEmployeeAsync(newEmployee);

            return Ok(employee);
        }

        [HttpPut]
        [Route("updateEmployee/{employeeId}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> UpdateEmployee(string employeeId, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest(MessageHelper<Employee>.ObjectNull());
            }

            if (employeeId != employee.EmployeeId)
            {
                return BadRequest(MessageHelper<Employee>.MismatchIds(employeeId, employee.EmployeeId));
            }

            if (await _employeeService.EmployeeExistsAsync(employeeId) == false)
            {
                return NotFound(MessageHelper<Employee>.NotFound(employeeId));
            }

            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);

            return Ok(updatedEmployee);
        }

        [HttpPut]
        [Route("inactivateEmployee/{employeeId}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> InactivateEmployee(string employeeId)
        {
            if (await _employeeService.EmployeeExistsAsync(employeeId) == false)
            {
                return NotFound(MessageHelper<Employee>.NotFound(employeeId));
            }

            await _employeeService.InactivateEmployeeAsync(employeeId);

            return Ok(MessageHelper<Employee>.Success());
        }

        [HttpDelete]
        [Route("deleteEmployee/{employeeId}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> DeleteEmployee(string employeeId)
        {
            if (await _employeeService.EmployeeExistsAsync(employeeId) == false)
            {
                return NotFound(MessageHelper<Employee>.NotFound(employeeId));
            }

            await _employeeService.DeleteEmployeeAsync(employeeId);

            return Ok(MessageHelper<Employee>.Success());
        }
    }
}
