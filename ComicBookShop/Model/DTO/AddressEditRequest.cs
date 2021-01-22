using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Model.DTO
{
    public class AddressEditRequest
    {

        public string Street { get; set; }
        public int Number { get; set; }
        public string Details { get; set; }

    }
}
