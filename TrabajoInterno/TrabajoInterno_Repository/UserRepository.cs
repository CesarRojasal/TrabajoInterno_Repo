using TrabajoInterno_Abstraccion;
using TrabajoInterno_Entities;

namespace TrabajoInterno_Repository
{
    public class UserRepository: IUserRepository
    {
        private static List<User> Users = new()
        {
            new() { Username = "admin", EmailAddress = "admin@email.com", Password = "pass", GivenName = "Name", Surname = "Surname", Role = "Administrator" },
            new() { Username = "standard", EmailAddress = "standard@email.com", Password = "pass", GivenName = "Name {ñ", Surname = "Burton", Role = "Standard" },
        };

        public User? Get() => Users.FirstOrDefault();
    }
}
