using BikeRental.Core;

namespace BikeRental.Interfases.Repository
{
    public interface ITypeRepository<T> : IRepository<T> where T : Type
    {
    }
}
