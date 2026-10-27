using MediatR;
using ProjectManagement_API.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.State.Queries.GetAllStates
{
    public class GetAllStatesQuery:IRequest<List<MasterDataDto>>
    {
    }
}
