using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBookShop.Model.Entity;

namespace ComicBookShop.Model.DTO
{
    public class ProfileResponse
    {
        public ProfileResponse(User user)
        {
            Username = user.Username;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            DeliveryAddress = new AddressResponse(user.DeliveryAddress);
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual AddressResponse DeliveryAddress { get; set; }
    }
}
