using MediatR;
using ProjectManagement_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
             _projectRepository = projectRepository;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {

            var projEntity = ProjectManagement_API.Core.Entities.Project.CreateProject(request.Name, request.Description, request.ManagerId);
      
             var result=await _projectRepository.AddAsync(projEntity);

            return result.Id;
        }
    }
}
