using Repository.Entities;
using Repository.Model;
using System.Linq;

namespace Repository.Repositories
{
    public class UserRepository
    {
        private readonly TaskContext _context;

        public UserRepository(TaskContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {          
            _context.Users.Add(user);

            _context.SaveChanges();

            return user;
        }

        public User GetByUsername(string username)
        {
            return _context.Users.Where(user => user.Username == username).FirstOrDefault();
        }
    }
}
