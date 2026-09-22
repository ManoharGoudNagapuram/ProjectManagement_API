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

    }
}
