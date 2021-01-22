using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Model.Entity
{
    public class Order : BaseEntity
    {
        public string UUID { get; set; }
        public string Details { get; set; }
        public int TotalPrice { get; set; }
        public virtual List<OrderComicBook> OrderComicBooks { get; set; }
        public virtual Address DeliveryAddress { get; set; }
        public virtual User OrderedByUser { get; set; }

    }
}
