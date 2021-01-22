using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBookShop.Model.DTO;
using ComicBookShop.Model.Entity;

namespace ComicBookShop.Service
{
    public interface IUserService
    {
        public ProfileResponse GetProfileByUsername(string username);
        public User GetUserByUsername(string username);
        public AuthenticationResponse RegisterUser(RegisterRequest registerRequest);
        public AuthenticationResponse LoginUser(LoginRequest loginRequest);
        public void EditAddress(User user, AddressEditRequest request);
    }
}
