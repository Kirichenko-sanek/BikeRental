using System.Collections.Generic;

namespace BikeRental.Core
{
    public class Photo : BaseEntity
    {
        public string Url { get; set; }

        public virtual List<User> User { get; set; }
        public virtual List<Bike> Bike { get; set; }

       public Photo()
        {
            User = new List<User>();
            Bike = new List<Bike>();
        }
    }
}
