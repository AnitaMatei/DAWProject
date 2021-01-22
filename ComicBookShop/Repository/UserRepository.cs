using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBookShop.Model.Entity;
using ComicBookShop.Context;
using Microsoft.EntityFrameworkCore;

namespace ComicBookShop.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MySqlContext context) : base(context)
        {

        }

        public User GetByUsername(string username)
        {
            return _context.Users.Where(u => u.Username == username)
                .Include(u => u.CartItems)
                .Include(u => u.DeliveryAddress)
                .FirstOrDefault();
        }
        public User GetByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email)
                .Include(u => u.CartItems)
                .Include(u => u.DeliveryAddress)
                .FirstOrDefault();
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return _context.Users.Where(u => u.Username.Equals(username))
                .Where(u => u.Password.Equals(password))
                .Include(u => u.CartItems)
                .Include(u => u.DeliveryAddress)
                .FirstOrDefault();
        }
    }
}
