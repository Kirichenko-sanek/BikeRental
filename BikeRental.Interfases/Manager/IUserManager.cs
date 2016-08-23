using BikeRental.Core;

namespace BikeRental.Interfases.Manager
{
    public interface IUserManager<T> : IManager<T> where T : User
    {
        User GetUserByEmail(string email);
    }
}
