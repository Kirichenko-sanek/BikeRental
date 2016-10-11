using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;
using BikeRental.Resources.App_GlobalResources;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.BL.Manager
{
    public class UserManager<T> : Manager<T>, IUserManager<T> where T : User
    {

        public UserManager(IRepository<T> repository, IValidator<T> validator)
            : base(repository, validator)
        {
        }

        public LoginViewModel LogIn(LoginViewModel model)
        {
            try
            {
                var user = GetAll().FirstOrDefault(x => x.Email == model.Email);
                if (user == null) throw new Exception(Resource.EmailNotRegistered);
                var pass = PasswordHashing.HashPassword(model.Password, user.PasswordSalt);
                if (user.Password != pass) throw new Exception(Resource.WrongPassword);
                if (!user.IsActivated) throw new Exception();
                model.Role = user.Roles.Role;              
                FormsAuthentication.SetAuthCookie(user.Email, true);
                model.IdUser = user.Id;
                return model;
            }
            catch (Exception e)
            {
                model.Error = e.Message;
                return model;
            }            
        }

        public LoginViewModel LogInApi(string email, string password)
        {
            var model = new LoginViewModel();
            try
            {
                var user = GetAll().FirstOrDefault(x => x.Email == email);
                if (user == null) throw new Exception(Resource.EmailNotRegistered);
                var pass = PasswordHashing.HashPassword(password, user.PasswordSalt);
                if (user.Password != pass) throw new Exception(Resource.WrongPassword);
                if (!user.IsActivated) throw new Exception();
                FormsAuthentication.SetAuthCookie(user.Email, false);
                model.IdUser = user.Id;
                model.Role = user.Roles.Role;
                return model;
            }
            catch (Exception e)
            {
                model.Error = e.Message;
                return model;
            }
        }

        public User GetUserByEmail(string email)
        {
            return GetAll().FirstOrDefault(x=>x.Email == email);
        }
    }
}
