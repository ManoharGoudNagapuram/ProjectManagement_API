using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ManagerId { get; set; }
    }
}
