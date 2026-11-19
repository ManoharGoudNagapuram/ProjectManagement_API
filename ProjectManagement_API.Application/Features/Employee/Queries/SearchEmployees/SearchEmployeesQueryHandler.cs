using AutoMapper;
using MediatR;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Employee.Queries.SearchEmployees
{
    public class SearchEmployeesQueryHandler : IRequestHandler<SearchEmployeesQuery, List<SearchResponseDto>>
    {
        private readonly IEmployeeSearchRepository _employeeSearchRepository;
        private readonly IMapper _mapper;
        public SearchEmployeesQueryHandler(IEmployeeSearchRepository employeeSearchRepository,
            IMapper mapper)
        {
                _employeeSearchRepository = employeeSearchRepository;
            _mapper = mapper;
        }
        public async Task<List<SearchResponseDto>> Handle(SearchEmployeesQuery request, CancellationToken cancellationToken)
        {
           var result= await _employeeSearchRepository.SearchEmployees(request.SearchKey, request.SortBy, request.SortOrder, request.PageNumber, request.PageSize);
            var response=_mapper.Map<List<SearchResponseDto>>(result);
            return response;
        }
    }
}
