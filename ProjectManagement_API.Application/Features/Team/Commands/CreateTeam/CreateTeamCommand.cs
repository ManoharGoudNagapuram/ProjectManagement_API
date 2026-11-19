using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Team.Commands.CreateTeam
{
    public class CreateTeamCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
    }
}
