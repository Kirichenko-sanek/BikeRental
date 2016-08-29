using BikeRental.ViewModel.Validators;
using FluentValidation.Attributes;

namespace BikeRental.ViewModel.ViewModel
{
    [Validator(typeof(LoginViewModelValidator))]
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Error { get; set; }
        public long IdUser { get; set; }
    }
}