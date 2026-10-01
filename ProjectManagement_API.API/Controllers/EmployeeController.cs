using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Application.Features.Employee.Commands;
using ProjectManagement_API.Core.Entities;

namespace ProjectManagement_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public EmployeeController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        //"ControllerBase" gives your controller useful methods and properties for
        //handling HTTP requests and generating HTTP responses.
        // Ex: Ok(data),Unauthorized(), so we can return like "return OK(data)" from our
        // controller action methods 

        //"IActionResult" return type can support different type of htp responses like 
        //Ok(employee), NotFound() and we can't return like that if we just use Employee as return type

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequestDto employeeRequest)
        {
            if (employeeRequest == null)
            {
                return BadRequest("No employees details found");
            }

            var empRequestCmd = _mapper.Map<CreateEmployeeCommand>(employeeRequest);

            var result = await _mediator.Send(empRequestCmd);

            return Ok(result);
        }
    }
}
