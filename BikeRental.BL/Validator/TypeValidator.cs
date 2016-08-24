using BikeRental.Core;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;

namespace BikeRental.BL.Validator
{
    public class TypeValidator : IValidator<Type>
    {
        private readonly IRepository<Type> _typeRepository;

        public TypeValidator(IRepository<Type> typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public bool IsExists(long id)
        {
            return _typeRepository.GetByID(id) != null;
        }

        public bool IsValid(Type entity)
        {
            return entity.NameType != null;
        }
    }
}
