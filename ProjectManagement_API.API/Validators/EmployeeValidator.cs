using FluentValidation;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Core.Entities;

namespace ProjectManagement_API.API.Validators
{
    public class EmployeeValidator:AbstractValidator<EmployeeRequestDto>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firstname is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required.");
            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("EmailAddress is required");
            RuleFor(x => x.DOB).NotNull().WithMessage("DOB is required");
            RuleFor(x=>x.DepartmentId).GreaterThan(0).WithMessage("Department is required.");
            RuleFor(x => x.Address).NotNull().WithMessage("Address is required.");
            RuleFor(x => x.Address.AddressLine1).NotNull().WithMessage("AddressLine1 is required.");
            RuleFor(x => x.Address.AddressLine2).NotNull().WithMessage("AddressLine2 is required.");
            RuleFor(x => x.Address.PostalCode).NotNull().WithMessage("PostalCode is required.");
            RuleFor(x => x.Address.City).NotNull().WithMessage("City is required.");
            RuleFor(x => x.Address.StateId).GreaterThan(0).WithMessage("State is required.");
            RuleFor(x => x.Address.CountryId).GreaterThan(0).WithMessage("Country is required.");
        }


    }
}
