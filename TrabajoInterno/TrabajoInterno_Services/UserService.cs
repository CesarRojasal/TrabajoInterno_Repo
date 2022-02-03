using TrabajoInterno_Abstraccion;
using TrabajoInterno_Entities;

namespace TrabajoInterno_Services
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
