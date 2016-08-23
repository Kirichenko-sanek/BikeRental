namespace BikeRental.Core
{
    public class Type : BaseEntity
    {
        public string NameType { get; set; }

        public virtual Bike Bike { get; set; }

       /* public Type()
        {
            Bike = new Bike();
        }*/
    }
}
