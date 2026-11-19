using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.TeamMember.Commands.CreateTeamMember
{
    public class CreateTeamMemberCommand:IRequest<int>
    {
        public int TeamId { get; set; }
        public int EmployeeId { get; set; }
    }
}
