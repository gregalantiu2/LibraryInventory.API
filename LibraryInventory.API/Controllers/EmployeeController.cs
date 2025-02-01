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
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult> SearchEmployees()
        {
            return Ok();
        }

        [HttpGet]
        [Route("getEmployee/{id}")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("addEmployee")]
        public async Task<ActionResult> AddEmployee([FromBody] string value)
        {
            return Ok();
        }

        [HttpPut]
        [Route("updateEmployee/{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpPut]
        [Route("inactivateEmployee/{id}")]
        public async Task<ActionResult> InactivateEmployee(int id)
        {
            return Ok();
        }
    }
}
