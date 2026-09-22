using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement_API.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetDepartments()
        {
            return Ok();

        }
    }
}
