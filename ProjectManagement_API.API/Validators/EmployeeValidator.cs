using FluentValidation;
using ProjectManagement_API.Application.Dtos;
using ProjectManagement_API.Core.Entities;

namespace ProjectManagement_API.API.Validators
{
    public class EmployeeValidator:AbstractValidator<EmployeeRequestDto>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firs Name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("Email Address is required");
            RuleFor(x => x.DOB).NotNull().WithMessage("DOB is required");
            RuleFor(x=>x.DepartmentId).GreaterThan(0).WithMessage("Department is required.");
            RuleFor(x => x.Address).NotNull().WithMessage("Address is required.");
            RuleFor(x => x.Address.AddressLine1).NotNull().WithMessage("Address Line1 is required.");
            RuleFor(x => x.Address.AddressLine2).NotNull().WithMessage("Address Line2 is required.");
            RuleFor(x => x.Address.PostalCode).NotNull().WithMessage("Postal Code is required.");
            RuleFor(x => x.Address.StateId).GreaterThan(0).WithMessage("State is required.");
            RuleFor(x => x.Address.CountryId).GreaterThan(0).WithMessage("Country is required.");
        }


    }
}
