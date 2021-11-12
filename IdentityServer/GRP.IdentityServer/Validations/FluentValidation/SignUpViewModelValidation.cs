
using FluentValidation;

using GRP.IdentityServer.Models;

namespace GRP.IdentityServer.Validations.FluentValidation
{
    public class SignUpViewModelValidation : AbstractValidator<SignUpViewModel>
    {
        public SignUpViewModelValidation()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email not valid");
            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Password is required");
        }
    }
}
