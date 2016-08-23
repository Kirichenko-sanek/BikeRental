using System.Collections.Generic;

namespace BikeRental.Core
{
    public class Roles : BaseEntity
    {
        public string Role { get; set; } 

        public virtual List<User> Users { get; set; }

        public Roles()
        {
            Users = new List<User>();
        }
    }
}
