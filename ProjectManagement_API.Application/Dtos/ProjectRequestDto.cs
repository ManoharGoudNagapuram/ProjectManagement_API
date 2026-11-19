using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Dtos
{
    public class ProjectRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ManagerId {  get; set; }
    }
}
