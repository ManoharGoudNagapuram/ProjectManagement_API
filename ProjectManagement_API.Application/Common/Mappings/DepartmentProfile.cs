using AutoMapper;
using ProjectManagement_API.Application.Features.Departments.Dtos;
using ProjectManagement_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Common.Mappings
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department,DepartmentDto>();
        }
    }
}
