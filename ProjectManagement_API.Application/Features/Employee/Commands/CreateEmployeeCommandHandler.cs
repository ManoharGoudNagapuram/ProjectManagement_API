using MediatR;
using ProjectManagement_API.Application.Exceptions;
using ProjectManagement_API.Core.Entities;
using ProjectManagement_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ProjectManagement_API.Core.Entities

namespace ProjectManagement_API.Application.Features.Employee.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
                _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var addressEntity = Address.Create(request.Address.AddressLine1,
                request.Address.AddressLine2,
                request.Address.City,
                request.Address.StateId,
                request.Address.PostalCode,
                request.Address.CountryId
                 );

            var employeeEntity = ProjectManagement_API.Core.Entities.Employee.Create(
                 request.FirstName,
                 request.LastName,
                 request.DOB,
                 request.EmailAddress,
                 request.PhoneNumber,
                 request.DepartmentId,
                 addressEntity
                );

           var result= await _employeeRepository.AddAsync(employeeEntity);

            if (result == null || result.Id <= 0)
            {
                throw new InternalServerException("employee entity save failed");
            }
            return result.Id;
        }
    }
}
