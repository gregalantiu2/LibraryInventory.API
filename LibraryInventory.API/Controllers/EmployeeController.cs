using AutoMapper;
using LibraryInventory.API.Extensions;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.RequestModels.Person;
using LibraryInventory.Model.SharedModels;
using LibraryInventory.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.IdentityModel.Tokens;

namespace LibraryInventory.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getEmployee/{employeeId}")]
        public async Task<ActionResult> GetEmployee(string employeeId)
        {
            if (employeeId.IsNullOrEmpty())
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(employeeId)));
            }

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
            if (employeeId.IsNullOrEmpty())
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(employeeId)));
            }

            var contactInfo = await _employeeService.GetEmployeeContactInfo(employeeId);

            if (contactInfo == null)
            {
                return NotFound(MessageHelper<ContactInfo>.NotFound(employeeId));
            }

            return Ok(contactInfo);
        }

        [HttpPost]
        [Route("addEmployee")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeRequest newEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _employeeService.AddEmployeeAsync(_mapper.Map<Employee>(newEmployee));

            return Ok(employee);
        }

        [HttpPut]
        [Route("updateEmployee/{employeeId}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> UpdateEmployee(string employeeId, [FromBody] EmployeeRequest employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (employeeId != employee.EmployeeId)
            {
                return BadRequest(MessageHelper<Employee>.MismatchIds(employeeId, employee.EmployeeId));
            }

            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(_mapper.Map<Employee>(employee));

            return Ok(updatedEmployee);
        }

        [HttpPut]
        [Route("inactivateEmployee/{employeeId}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> InactivateEmployee(string employeeId)
        {
            if (employeeId.IsNullOrEmpty())
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(employeeId)));
            }

            await _employeeService.InactivateEmployeeAsync(employeeId);

            return Ok(MessageHelper<Employee>.Success());
        }

        [HttpDelete]
        [Route("deleteEmployee/{employeeId}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        public async Task<ActionResult> DeleteEmployee(string employeeId)
        {
            if (employeeId.IsNullOrEmpty())
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(employeeId)));
            }

            await _employeeService.DeleteEmployeeAsync(employeeId);

            return Ok(MessageHelper<Employee>.Success());
        }
    }
}
