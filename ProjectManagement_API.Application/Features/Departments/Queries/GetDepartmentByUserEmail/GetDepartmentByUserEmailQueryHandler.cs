using AutoMapper;
using MediatR;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Application.Exceptions;
using ProjectManagement_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Departments.Queries.GetDepartmentByUserEmail
{
    public class GetDepartmentByUserEmailQueryHandler : IRequestHandler<GetDepartmentByUserEmailQuery, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public GetDepartmentByUserEmailQueryHandler(IDepartmentRepository departmentRepository,
            IMapper mapper)
        {
                 _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<DepartmentDto> Handle(GetDepartmentByUserEmailQuery request, CancellationToken cancellationToken)
        {
            if(request==null || string.IsNullOrWhiteSpace(request.UserEmailAddress))
            {
                 throw new ValidationException("UserEmailAddress is required.");
            }
            var result=await _departmentRepository.GetDepartmentByUserEmailAsync(request.UserEmailAddress);

            if (result == null)
            {
                throw new NotFoundException("Department not found");
            }

            var depDto = _mapper.Map<DepartmentDto>(result);
            return depDto;
           
        }
    }
}
