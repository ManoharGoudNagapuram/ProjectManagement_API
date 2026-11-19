using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Application.Features.Team.Commands.CreateTeam;

namespace ProjectManagement_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] TeamRequestDto requestDto)
        {

            if (requestDto == null)
            {
                return BadRequest("Team details required");
            }

            var commnd=new CreateTeamCommand { 
                Name = requestDto.Name, 
                Description=requestDto.Description,
                ProjectId=requestDto.ProjectId,
            };
            await _mediator.Send(commnd);

            return Ok();

        }
    }
}
