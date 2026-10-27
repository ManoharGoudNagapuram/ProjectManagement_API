using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement_API.API.Response;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Application.Features.Departments.Queries.GetAllDepartments;
using System.Linq.Expressions;

namespace ProjectManagement_API.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/departments")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public DepartmentController(IMediator mediatR) { 
            _mediatR = mediatR;
        }

        [HttpGet]
        [Authorize(Policy = "adminrole_policy")]
        public async Task<IActionResult> GetDepartments()
        {
           var result=await _mediatR.Send(new GetAllDepartmentsQuery());

            var response = new ListResult<DepartmentDto> { Data = result, Error = null, Success = true };

            return Ok(response);

        }
    }
}
