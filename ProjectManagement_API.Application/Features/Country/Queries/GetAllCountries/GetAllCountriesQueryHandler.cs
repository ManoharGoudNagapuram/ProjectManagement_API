using AutoMapper;
using MediatR;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Country.Queries.GetAllCountries
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, List<MasterDataDto>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public GetAllCountriesQueryHandler(ICountryRepository countryRepository,
            IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<List<MasterDataDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _countryRepository.GetAllAsync();
            var resDto = _mapper.Map<List<MasterDataDto>>(result);
            return resDto;
        }
    }
}
