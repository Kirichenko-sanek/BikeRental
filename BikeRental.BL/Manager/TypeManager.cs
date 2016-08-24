using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;

namespace BikeRental.BL.Manager
{
    public class TypeManager<T> : Manager<T>, ITypeManager<T> where T : Type
    {
        private readonly ITypeRepository<Type> _typeRepository;

        public TypeManager(ITypeRepository<Type> typeRepository, IRepository<T> repository, IValidator<T> validator)
            : base(repository, validator)
        {
            _typeRepository = typeRepository;
        }
    }
}
