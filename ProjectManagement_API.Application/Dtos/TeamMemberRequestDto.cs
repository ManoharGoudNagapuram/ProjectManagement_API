using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Dtos
{
    public class TeamMemberRequestDto
    {
        public int TeamId { get; set; }
        public int EmployeeId { get; set; }
    }
}
