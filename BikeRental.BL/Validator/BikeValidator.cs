using BikeRental.Core;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;

namespace BikeRental.BL.Validator
{
    public class BikeValidator : IValidator<Bike>
    {
        private readonly IRepository<Bike> _bikeRepository;

        public BikeValidator(IRepository<Bike> bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public bool IsExists(long id)
        {
            return _bikeRepository.GetByID(id) != null;
        }

        public bool IsValid(Bike entity)
        {
            return true;
        }
    }
}
