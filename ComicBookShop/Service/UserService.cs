using ComicBookShop.Exceptions;
using ComicBookShop.Model;
using ComicBookShop.Model.DTO;
using ComicBookShop.Model.Entity;
using ComicBookShop.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShop.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IAddressRepository addressRepository;
        private readonly AppSettings appSettings;

        public UserService(IUserRepository userRepository, IAddressRepository addressRepository, IOptions<AppSettings> appSettings)
        {
            this.userRepository = userRepository;
            this.addressRepository = addressRepository;
            this.appSettings = appSettings.Value;
        }

        public ProfileResponse GetProfileByUsername(string username)
        {
            return new ProfileResponse(userRepository.GetByUsername(username));
        }

        public User GetUserByUsername(string username)
        {
            return userRepository.GetByUsername(username);
        }

        public AuthenticationResponse RegisterUser(RegisterRequest registerRequest)
        {
            if (!IsUsernameAndEmailUnique(registerRequest) || !IsPasswordValid(registerRequest))
                throw new HttpResponseException
                {
                    Status = 401
                };

            var user = new User(registerRequest);

            userRepository.Create(user);
            userRepository.SaveChanges();
            return new AuthenticationResponse { JwtToken = GenerateJwtForUser(user) };
        }
        public AuthenticationResponse LoginUser(LoginRequest loginRequest)
        {
            var user = userRepository.GetByUsernameAndPassword(loginRequest.Username, loginRequest.Password);
            if(user == null)
                throw new HttpResponseException
                {
                    Status = 401
                };

            return new AuthenticationResponse { JwtToken = GenerateJwtForUser(user) };
        }

        public void EditAddress(User user, AddressEditRequest editRequest)
        {
            Address address = new Address(editRequest);
            if(user.DeliveryAddress!=null)
            {
                addressRepository.Delete(user.DeliveryAddress);
            }
            user.DeliveryAddress = address;

            userRepository.Update(user);

            userRepository.SaveChanges();
            addressRepository.SaveChanges();

        }





        private bool IsUsernameAndEmailUnique(RegisterRequest registerRequest)
        {
            return ((userRepository.GetByUsername(registerRequest.Username) == null) &&
                userRepository.GetByEmail(registerRequest.Email) == null);
        }

        private bool IsPasswordValid(RegisterRequest registerRequest)
        {
            return true;
        }
        private string GenerateJwtForUser(User user)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("username", user.Username.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
