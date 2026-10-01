using MediatR;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Features.Employee.Commands
{
    public class CreateEmployeeCommand: IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }

        public AddressModel Address { get; set; }
    }
    public class AddressModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string PostalCode { get; set; }
        public int CountryId { get; set; }

    }
}
