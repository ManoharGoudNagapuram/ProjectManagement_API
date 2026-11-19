using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Application.Features.Project.Commands.CreateProject;

namespace ProjectManagement_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
                _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] ProjectRequestDto requestDto)
        {
            var CreateProjCommd=new CreateProjectCommand { 
                Name = requestDto.Name,
                Description=requestDto.Description,
                ManagerId=requestDto.ManagerId
            };

            var result= await _mediator.Send(CreateProjCommd);

            return Ok();
        }
    }
}
