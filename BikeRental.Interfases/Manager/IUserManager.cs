using BikeRental.Core;
using BikeRental.ViewModel;

namespace BikeRental.Interfases.Manager
{
    public interface IUserManager<T> : IManager<T> where T : User
    {
        LoginViewModel LogIn(LoginViewModel model);
        User GetUserByEmail(string email);
    }
}
