using MediatR;
using ProjectManagement_API.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Country.Queries.GetAllCountries
{
    public class GetAllCountriesQuery:IRequest<List<MasterDataDto>>
    {
    }
}
