using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement_API.API.Response;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Application.Features.Country.Queries.GetAllCountries;

namespace ProjectManagement_API.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountryController(IMediator mediator)
        {
                _mediator = mediator;
        }

        [HttpGet("countries")]
        public async Task<IActionResult>Get()
        {
            var result= await _mediator.Send(new GetAllCountriesQuery());
            var response = new ListResult<MasterDataDto> { Data = result, Error = null, Success = true };

            return Ok(response);
        }
    }
}
