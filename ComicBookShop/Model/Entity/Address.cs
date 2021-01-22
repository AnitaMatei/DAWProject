using ComicBookShop.Model.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Model.Entity
{
    public class Address : BaseEntity
    {
        public Address()
        {
            UserDeliveries = new List<User>();
            Orders = new List<Order>();
        }
        public Address(AddressEditRequest address)
        {
            Street = address.Street;
            Number = address.Number;
            Details = address.Details;
            UserDeliveries = new List<User>();
            Orders = new List<Order>();
        }

        public string Street { get; set; }
        public int Number { get; set; }
        public string Details { get; set; }
        [JsonIgnore]
        public virtual List<User> UserDeliveries { get; set; }
        [JsonIgnore]
        public virtual List<Order>? Orders { get; set; }
    }
}
