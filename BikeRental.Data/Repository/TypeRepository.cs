using BikeRental.Core;
using BikeRental.Interfases.Repository;

namespace BikeRental.Data.Repository
{
    public class TypeRepository<T> : Repository<T>, ITypeRepository<T> where T : Type
    {
        public TypeRepository(DataContext context) : base(context)
        {           
        }
    }
}
