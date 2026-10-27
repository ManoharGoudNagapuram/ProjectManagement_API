using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement_API.API.Response;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Application.Features.Departments.Queries.GetAllDepartments;
using ProjectManagement_API.Application.Features.State.Queries.GetAllStates;

namespace ProjectManagement_API.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    [Authorize]
    public class StateController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public StateController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("states")]
        public async Task<IActionResult> GetStates()
        {
            var result = await _mediatR.Send(new GetAllStatesQuery());

            var response = new ListResult<MasterDataDto> { Data = result, Error = null, Success = true };

            return Ok(response);

        }
    }
}
