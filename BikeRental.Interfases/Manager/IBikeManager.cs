using System;
using System.Linq;
using BikeRental.Core;

namespace BikeRental.Interfases.Manager
{
    public interface IBikeManager<T> : IManager<T> where T : Bike
    {
        IQueryable<Bike> SerchBikes(string type, string sex);
    }
}
