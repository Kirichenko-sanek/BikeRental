using System.Linq;
using BikeRental.Core;
using BikeRental.Interfases.Repository;

namespace BikeRental.Data.Repository
{
    public class BikeRepository<T> : Repository<T>,IBikeRepository<T> where T : Bike
    {
        public BikeRepository(DataContext context) : base(context)
        {
            
        }

        public Bike SerchBikes(string type, string sex)
        {
            return
                _context.Bikes.FirstOrDefault(
                    x =>
                        (x.Type.NameType == type && x.Sex == sex && x.Status == true) ||
                        ((x.Type.NameType == type || x.Sex == sex) && x.Status == true) || (x.Status == true));
        }
    }
}
