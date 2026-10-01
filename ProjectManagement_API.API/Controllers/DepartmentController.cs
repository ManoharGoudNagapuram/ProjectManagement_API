using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement_API.Application.Features.Departments.Queries.GetAllDepartments;

namespace ProjectManagement_API.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public DepartmentController(IMediator mediatR) { 
            _mediatR = mediatR;
        }

        [HttpGet()]
        public async Task<IActionResult> GetDepartments()
        {
           var result=await _mediatR.Send(new GetAllDepartmentsQuery());
            return Ok(result);

        }
    }
}
