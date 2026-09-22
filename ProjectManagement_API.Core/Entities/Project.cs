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
    }
}
