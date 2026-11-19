using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Entities
{
    public class Project:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId {  get; set; }
        public int ManagerId { get; set; }

        public Status Status { get; set; }
        public Employee Manager { get; set; }

        private Project()
        {

        }

        private Project(string name, string description, int statusId, int managerId)
        {
            Name = name;
            Description = description;
            StatusId = statusId;
            ManagerId = managerId;
        }

        public static Project CreateProject(string name, string description, int managerId)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Project Name is required.");
            if (name.Length>200)
            {
                throw new Exception("Project Name is max 200 chars.");
            }
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException("Project description is missed.");
            if (managerId <= 0) throw new ArgumentOutOfRangeException("Project managerId is required.");

            //statusId=1 is not started
            Project project = new Project(name,description,1,managerId);
            return project;
        }
    }
}
