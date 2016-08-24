using System.Linq;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;

namespace BikeRental.BL.Manager
{
    public class BikeManager<T> : Manager<T>, IBikeManager<T> where T : Bike
    {
        private readonly IBikeRepository<Bike> _bikeRepository;

        public BikeManager(IBikeRepository<Bike> bikeRepository, IRepository<T> repository, IValidator<T> validator)
            : base(repository, validator)
        {
            _bikeRepository = bikeRepository;
        }

        public IQueryable<Bike> SerchBikes(string type, string sex)
        {
            return _bikeRepository.SerchBikes(type, sex);
        }
    }
}
