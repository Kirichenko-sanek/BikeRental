namespace BikeRental.Core
{
    public class Photo : BaseEntity
    {
        public string Url { get; set; }

        public virtual User User { get; set; }
        public virtual Bike Bike { get; set; }

       /* public Photo()
        {
            User = new User();
            Bike = new Bike();
        }*/
    }
}
