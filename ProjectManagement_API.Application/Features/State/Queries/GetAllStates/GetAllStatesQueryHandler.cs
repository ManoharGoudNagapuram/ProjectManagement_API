using AutoMapper;
using MediatR;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.State.Queries.GetAllStates
{
    public class GetAllStatesQueryHandler : IRequestHandler<GetAllStatesQuery, List<MasterDataDto>>
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;
        public GetAllStatesQueryHandler(IMapper mapper, IStateRepository stateRepository)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }
        public async Task<List<MasterDataDto>> Handle(GetAllStatesQuery request, CancellationToken cancellationToken)
        {
            var result = await _stateRepository.GetAllAsync();
            var  resDto= _mapper.Map<List<MasterDataDto>>(result);
            return resDto;
        }
    }
}
