using System.Linq;
using BikeRental.Core;

namespace BikeRental.Interfases.Manager
{
    public interface IBikeManager<T> : IManager<T> where T : Bike
    {
        Bike SerchBikes(string type, string sex);
    }
}
