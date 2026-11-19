using ProjectManagement_API.Core.Entities;
using ProjectManagement_API.Core.Interfaces;
using ProjectManagement_API.Infrastracture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Infrastracture.Repositories
{
    public class TeamMemberRepository : BaseRepository<TeamMembers>, ITeamMemberRepository
    {
        public TeamMemberRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
