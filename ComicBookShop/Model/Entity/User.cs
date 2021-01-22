using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using ComicBookShop.Model.DTO;

namespace ComicBookShop.Model.Entity
{
    public class User : BaseEntity
    {
        public User(RegisterRequest request)
        {
            Username = request.Username;
            Password = request.Password;
            Email = request.Email;
            Orders = new List<Order>();
            CartItems = new List<CartItem>();
        }

        public User()
        {
            Orders = new List<Order>();
            CartItems = new List<CartItem>();
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }

        [ForeignKey("DeliveryAddressID")]
        public virtual Address? DeliveryAddress {get;set; }
        public virtual List<Order>? Orders { get; set; }
        public virtual List<CartItem>? CartItems { get; set; }
    }
}
