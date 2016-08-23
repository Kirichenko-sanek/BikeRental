using BikeRental.Core;

namespace BikeRental.Interfases.Repository
{
    public interface IUserRepository<T> : IRepository<T> where T : User
    {
        User GetUserByEmail(string email);
    }
}
