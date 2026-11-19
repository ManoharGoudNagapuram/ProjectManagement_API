using MediatR;
using ProjectManagement_API.Application.Exceptions;
using ProjectManagement_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.TeamMember.Commands.CreateTeamMember
{
    public class CreateTeamMemberCommandHandler : IRequestHandler<CreateTeamMemberCommand, int>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public CreateTeamMemberCommandHandler(ITeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }
        public async Task<int> Handle(CreateTeamMemberCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ValidationException($"{nameof(request)} details required.");
            }

              var teamMemberEntity = ProjectManagement_API.Core.Entities.TeamMembers.CreateTeamMember(request.TeamId, request.EmployeeId);

              var res=  await _teamMemberRepository.AddAsync(teamMemberEntity);
            
              return res.Id;
        }
    }
}
