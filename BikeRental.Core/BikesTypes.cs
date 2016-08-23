namespace BikeRental.Core
{
    public class BikesTypes : BaseEntity
    {
        public long IdBike { get; set; }
        public long IdType { get; set; }

        public virtual Bike Bike { get; set; }
        public virtual Type Type { get; set; }
    }
}
