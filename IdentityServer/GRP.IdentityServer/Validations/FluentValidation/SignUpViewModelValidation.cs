
using FluentValidation;

using GRP.IdentityServer.Models;

namespace GRP.IdentityServer.Validations.FluentValidation
{
    public class SignUpViewModelValidation : AbstractValidator<SignUpViewModel>
    {
        public SignUpViewModelValidation()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
          
            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Parola boş geçilemez");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş geçilemez")
                .MaximumLength(40).WithMessage("Ad 40 karakterden uzun olamaz");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş geçilemez")
                .MaximumLength(40).WithMessage("Soyad 40 karakterden uzun olamaz");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres boş geçilemez")
                .MaximumLength(200).WithMessage("Adres 200 karakterden uzun olamaz");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş geçilemez")
                .Matches("^(05)[0-9][0-9][1-9]([0-9]){6}$").WithMessage("Telefon numarası formatı hatalı");

            RuleFor(x => x.IdentityNumber)
               .NotEmpty().WithMessage("Kimlik numarası boş geçilemez")
               .Matches("^[1-9]{1}[0-9]{9}[02468]{1}$").WithMessage("Kimlik numarası formatı hatalı");

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Email boş geçilemez")
               .EmailAddress().WithMessage("Email formatı hatalı");

            RuleForEach(x => x.Roles)
              .NotNull().WithMessage("Roller boş geçilemez")
              .NotEmpty().WithMessage("Roller boş geçilemez");

        }
    }
}
