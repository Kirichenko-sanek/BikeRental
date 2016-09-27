using BikeRental.Core;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.Interfases.Manager
{
    public interface IUserManager<T> : IManager<T> where T : User
    {
        LoginViewModel LogIn(LoginViewModel model);
        LoginViewModel LogInApi(string email, string password);
        User GetUserByEmail(string email);
    }
}
