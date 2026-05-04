using EmployerService.Api.Models;
using FluentValidation;

namespace EmployerService.Api.ModelValidators
{
    public class NewEmployerValidator : AbstractValidator<NewEmployer>
    {
        public NewEmployerValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("UserId must be a valid GUID.");
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("CompanyName is required.")
                .MaximumLength(200).WithMessage("CompanyName cannot exceed 200 characters.");
            RuleFor(x => x.Industry)
                .NotEmpty().WithMessage("Industry is required.")
                .MaximumLength(100).WithMessage("Industry cannot exceed 100 characters.");
            RuleFor(x => x.CompanySize)
                .NotEmpty().WithMessage("CompanySize is required.");
            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("ContactEmail is required.")
                .EmailAddress().WithMessage("ContactEmail must be a valid email address.");
        }
    }
}
