using TrabajoInterno_Api.Interfaces;
using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public User? Get(UserLogin user)
        {
            return userRepository.Get();
        }
    }
}
