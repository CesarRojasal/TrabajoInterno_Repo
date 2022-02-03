using TrabajoInterno_Entities;

namespace TrabajoInterno_Abstraccion
{
    public interface IUserService
    {
        public User? Get(UserLogin user);
    }
}
