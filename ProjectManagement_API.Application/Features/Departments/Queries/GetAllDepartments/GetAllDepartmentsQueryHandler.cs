using AutoMapper;
using MediatR;
using ProjectManagement_API.Application.Dtos;
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
        private readonly IMapper _mapper;
        public GetAllDepartmentsQueryHandler(
            IDepartmentRepository departmentRepository,
            IMapper mapper)
        {
             _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<List<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var result= await _departmentRepository.GetAllAsync();
            var res= _mapper.Map<List<DepartmentDto>>(result);
            return res;
        }
    }

}
