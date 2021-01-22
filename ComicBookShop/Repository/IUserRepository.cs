using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBookShop.Model.Entity;

namespace ComicBookShop.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetByUsername(string username);
        public User GetByEmail(string email);
        public User GetByUsernameAndPassword(string username, string password);
    }
}
