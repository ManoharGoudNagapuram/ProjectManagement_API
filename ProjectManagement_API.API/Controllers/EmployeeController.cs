using Asp.Versioning;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Application.Exceptions;
using ProjectManagement_API.Application.Features.Employee.Commands;
using ProjectManagement_API.Core.Entities;
using ApplicationExceptions = ProjectManagement_API.Application.Exceptions;

namespace ProjectManagement_API.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/employee")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IValidator<EmployeeRequestDto> _validator;
        public EmployeeController(IMapper mapper, 
            IMediator mediator,
            IValidator<EmployeeRequestDto> validator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _validator = validator;
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
            var validResult=await _validator.ValidateAsync(employeeRequest);

            if (!validResult.IsValid)
            {
              var errors=   validResult.Errors.GroupBy(x=>x.PropertyName).ToDictionary(x=>x.Key,x=>x.Select(y=>y.ErrorMessage).ToArray());
               return BadRequest(new { errors });
            }
            if (employeeRequest == null)
            {
                throw new ApplicationExceptions.ValidationException("Employee details required.");
            }
            if (employeeRequest.Address == null)
            {
                throw new ApplicationExceptions.ValidationException("Address details required.");
            }

            var empRequestCmd = _mapper.Map<CreateEmployeeCommand>(employeeRequest);

            var result = await _mediator.Send(empRequestCmd);

            return Ok(result);
        }
    }
}
