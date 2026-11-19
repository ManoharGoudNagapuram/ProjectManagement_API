using MediatR;
using ProjectManagement_API.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Departments.Queries.GetDepartmentByUserEmail
{
    public class GetDepartmentByUserEmailQuery:IRequest<DepartmentDto>
    {
        public string UserEmailAddress { get; set; }
    }
}
