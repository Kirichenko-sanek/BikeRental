namespace BikeRental.Core
{
    public class Roles : BaseEntity
    {
        public string Role { get; set; } 
        
        public virtual User User { get; set; }

        /*public Roles()
        {
            User = new User();
        }*/
    }
}
