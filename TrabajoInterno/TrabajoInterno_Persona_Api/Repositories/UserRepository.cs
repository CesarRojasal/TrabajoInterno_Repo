using TrabajoInterno_Api.Interfaces;
using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Repositories
{
    public class UserRepository: IUserRepository
    {
        private static List<User> Users = new()
        {
            new() { Username = "_admin", EmailAddress = "admin@email.com", Password = "MyPass_w0rd", GivenName = "Name", Surname = "Surname", Role = "Administrator" },
            new() { Username = "_standard", EmailAddress = "standard@email.com", Password = "MyPass_w0rd", GivenName = "Name {ñ", Surname = "Burton", Role = "Standard" },
        };

        public User? Get()
        {
           return Users.FirstOrDefault();
        }
    }
}
