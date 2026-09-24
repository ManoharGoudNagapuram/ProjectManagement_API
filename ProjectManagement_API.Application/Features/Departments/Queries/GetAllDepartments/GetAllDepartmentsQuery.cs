using MediatR;
using ProjectManagement_API.Application.Features.Departments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Departments.Queries.GetAllDepartments
{
    public record GetAllDepartmentsQuery():IRequest<List<DepartmentDto>>;
    
}
