using TrabajoInterno_Abstraccion;
using TrabajoInterno_Entities;

namespace TrabajoInterno_Repository
{
    public class UserRepository: IUserRepository
    {
        private static List<User> Users = new()
        {
            new() { Username = "_admin", EmailAddress = "admin@email.com", Password = "MyPass_w0rd", GivenName = "Name", Surname = "Surname", Role = "Administrator" },
            new() { Username = "_standard", EmailAddress = "standard@email.com", Password = "MyPass_w0rd", GivenName = "Name {ñ", Surname = "Burton", Role = "Standard" },
        };

        public User? Get() => Users.FirstOrDefault();
    }
}
