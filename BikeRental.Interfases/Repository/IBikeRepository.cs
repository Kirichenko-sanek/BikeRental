using System;
using System.Linq;
using BikeRental.Core;

namespace BikeRental.Interfases.Repository
{
    public interface IBikeRepository<T> : IRepository<T> where T : Bike
    {
        IQueryable<Bike> SerchBikes(string type, string sex);
    }
}
