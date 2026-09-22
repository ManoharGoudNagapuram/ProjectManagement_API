using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Entities
{
    public class TaskComments:BaseEntity
    {
        public int ProjectTaskId {  get; set; }
        public string Comment {  get; set; }

        public ProjectTasks ProjectTasks { get; set; }
    }
}
