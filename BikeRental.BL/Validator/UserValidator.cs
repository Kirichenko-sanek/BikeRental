using System.Linq;
using BikeRental.Core;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;

namespace BikeRental.BL.Validator
{
    public class UserValidator : IValidator<User>
    {
        private readonly IRepository<User> _userRepository;

        public UserValidator(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsExists(long id)
        {
            return _userRepository.GetByID(id) != null;
        }

        public bool IsValid(User entity)
        {
            return _userRepository.GetAll().FirstOrDefault(m => m.Email == entity.Email) == null
                 && !string.IsNullOrEmpty(entity.FirstName)
                 && !string.IsNullOrEmpty(entity.LastName)
                 && !string.IsNullOrEmpty(entity.Email)
                 && !string.IsNullOrEmpty(entity.Password)
                 && !string.IsNullOrEmpty(entity.PasswordSalt);
        }
    }
}
