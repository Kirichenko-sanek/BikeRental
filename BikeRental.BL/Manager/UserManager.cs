using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;

namespace BikeRental.BL.Manager
{
    public class UserManager<T> : Manager<T>, IUserManager<T> where T : User
    {
        private readonly IUserRepository<User> _userRepository;

        public UserManager(IUserRepository<User> userRepository, IRepository<T> repository, IValidator<T> validator)
            : base(repository, validator)
        {
            _userRepository = userRepository;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }
    }
}
