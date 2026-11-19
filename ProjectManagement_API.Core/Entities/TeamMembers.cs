using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Entities
{
    public class TeamMembers:BaseEntity
    {
        public int TeamId {  get; set; }
        public int EmployeeId {  get; set; }

        public Team Team { get; set; }
        public Employee Employee { get; set; }

        private TeamMembers() { }

        private TeamMembers(int teamId, int employeeId)
        {
            TeamId = teamId;
            EmployeeId = employeeId;
        }

        public static TeamMembers CreateTeamMember(int teamId, int employeeId)
        {
            if (teamId <= 0)
                throw new ArgumentException("TeamId of team meber is required");

            if (employeeId <= 0)
                throw new ArgumentException("EmployeeId of team meber is required");

            return new TeamMembers(teamId, employeeId);
        }
    }
}
