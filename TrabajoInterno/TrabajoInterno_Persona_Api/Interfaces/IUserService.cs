using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Interfaces
{
    public interface IUserService
    {
        public User? Get(UserLogin user);
    }
}
