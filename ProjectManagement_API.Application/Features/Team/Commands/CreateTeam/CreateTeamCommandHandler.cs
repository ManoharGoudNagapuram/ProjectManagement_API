using MediatR;
using ProjectManagement_API.Application.Exceptions;
using ProjectManagement_API.Core.Entities;
using ProjectManagement_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Team.Commands.CreateTeam
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, int>
    {
        private readonly ITeamRepository _teamRepository;
        public CreateTeamCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<int> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            if(request==null) throw new ValidationException("Team details required");

           var teamEntity = ProjectManagement_API.Core.Entities.Team.CreateTeam(request.ProjectId, request.Name, request.Description);
           var result= await _teamRepository.AddAsync(teamEntity);
            return result.Id;
        }
    }
}
