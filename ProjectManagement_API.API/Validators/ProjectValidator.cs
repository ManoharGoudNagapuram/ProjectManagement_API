using FluentValidation;
using ProjectManagement_API.Application.Dtos;

namespace ProjectManagement_API.API.Validators
{
    public class ProjectValidator:AbstractValidator<ProjectRequestDto>
    {
        public ProjectValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Project Name is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Project Description is required.");
            RuleFor(x => x.ManagerId).LessThanOrEqualTo(0).WithMessage("Project Manager is required.");
        }
    }
}
