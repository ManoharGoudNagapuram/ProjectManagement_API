using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Entities
{
    public class ProjectTasks:BaseEntity
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal EstimationHours {  get; set; }
        public int AssignedTo {  get; set; }
        public int StatusId {  get; set; }

        public Project Project { get; set; }
        public Status Status { get; set; }
        public Employee Employee { get; set; }

        public ICollection<TaskComments> TaskComments { get; set; }=new List<TaskComments>();
    }
}
