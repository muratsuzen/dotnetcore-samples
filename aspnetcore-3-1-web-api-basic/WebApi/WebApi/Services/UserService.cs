using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Services
{
    public interface IUserService
    {
        User Authenticate(string userName, string password);
        List<User> GetAll();
    }
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Murat", LastName = "Suzen", UserName = "murat", Password = "1234" }
        };
        public User Authenticate(string userName, string password)
        {
            var user = _users.FirstOrDefault(x => x.UserName == userName && x.Password == password);

            return user;
        }

        public List<User> GetAll()
        {
            return _users;
        }
    }
}
