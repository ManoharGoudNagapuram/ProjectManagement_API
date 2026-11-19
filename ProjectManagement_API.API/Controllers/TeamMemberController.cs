using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Application.Features.TeamMember.Commands.CreateTeamMember;

namespace ProjectManagement_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeamMemberController(IMediator mediator)
        {
                _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeamMember([FromBody] TeamMemberRequestDto requestDto)
        {
            if(requestDto == null)
            {
                return BadRequest("TeamMember details required.");
            }
            var cmd= new CreateTeamMemberCommand { TeamId = requestDto.TeamId, EmployeeId=requestDto.EmployeeId };
            await _mediator.Send(cmd);

            return Ok();
        }
    }
}
