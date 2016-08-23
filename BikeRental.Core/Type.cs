using System.Collections.Generic;

namespace BikeRental.Core
{
    public class Type : BaseEntity
    {
        public string NameType { get; set; }

        public virtual List<BikesTypes> Bikes { get; set; }

        public Type()
        {
            Bikes = new List<BikesTypes>();
        }
    }
}
