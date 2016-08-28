using BikeRental.Resources.App_GlobalResources;
using BikeRental.ViewModel;
using FluentValidation;

namespace BikeRental.Validators
{
    public class BikeViewModelValidator : AbstractValidator<BikeViewModel>
    {
        public BikeViewModelValidator()
        {
            RuleFor(p => p.IdType).NotEmpty().WithMessage(Resource.SelectTheType);
            RuleFor(p => p.Sex).NotEmpty().WithMessage(Resource.SelectTheSex);
            RuleFor(p => p.Price).NotEmpty().WithMessage(Resource.SelectThePrise);
        }
    }
}