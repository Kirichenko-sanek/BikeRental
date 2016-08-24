using BikeRental.Core;

namespace BikeRental.Interfases.Manager
{
    public interface ITypeManager<T> : IManager<T> where T : Type
    {
    }
}
