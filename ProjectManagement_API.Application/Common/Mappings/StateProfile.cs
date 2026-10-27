using AutoMapper;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Common.Mappings
{
    public class StateProfile:Profile
    {
        public StateProfile()
        {
                CreateMap<State,MasterDataDto>().ReverseMap();
        }
    }
}
