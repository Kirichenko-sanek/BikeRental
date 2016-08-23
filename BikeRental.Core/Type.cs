using System.Collections.Generic;

namespace BikeRental.Core
{
    public class Type : BaseEntity
    {
        public string NameType { get; set; }

        public virtual List<Bike> Bike { get; set; }

        public Type()
        {
            Bike = new List<Bike>();
        }
    }
}
