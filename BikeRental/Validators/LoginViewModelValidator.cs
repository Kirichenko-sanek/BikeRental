using BikeRental.ViewModel;
using FluentValidation;

namespace BikeRental.Validators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("jk").EmailAddress().WithMessage("kll");
            RuleFor(p => p.Password).NotEmpty().WithMessage("kl");
        }
    }
}