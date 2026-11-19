using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Entities
{
    public class Team:BaseEntity
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Project Project { get; set; }


        private Team()
        {

        }

        private Team(int projectId, string name, string description)
        {
            ProjectId = projectId;
            Name = name;
            Description = description;
        }

        public static Team CreateTeam(int projectId, string name, string description)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Team name is required.");
            if (name.Length > 150) throw new Exception("Team name length should be max 150 chars");
            if (projectId <= 0) throw new ArgumentNullException("ProjectId is required");

            return new Team(projectId, name, description);
        }
    }
}
