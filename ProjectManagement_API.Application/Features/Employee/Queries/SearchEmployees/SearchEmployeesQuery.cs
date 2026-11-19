using MediatR;
using ProjectManagement_API.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Employee.Queries.SearchEmployees
{
    public class SearchEmployeesQuery:IRequest<List<SearchResponseDto>>
    {
        public  string SearchKey { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
