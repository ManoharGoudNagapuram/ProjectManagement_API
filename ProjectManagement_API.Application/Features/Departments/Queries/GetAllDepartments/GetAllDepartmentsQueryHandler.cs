using MediatR;
using ProjectManagement_API.Application.Features.Departments.Dtos;
using ProjectManagement_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
        {
             _departmentRepository = departmentRepository;
        }
        public async Task<List<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var result= await _departmentRepository.GetAllAsync();
            throw new NotImplementedException();
        }
    }

}
