using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Model.DTO
{
    public class AddressResponse
    {
        public AddressResponse()
        {
        }
        public AddressResponse(Address address)
        {
            Street = address.Street;
            Number = address.Number;
            Details = address.Details;
        }

        public string Street { get; set; }
        public int Number { get; set; }
        public string Details { get; set; }
    }
}
