using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBookShop.Enum;

namespace ComicBookShop.Model.Entity
{
    public class ComicBook : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public int Price { get; set; }
        public DateTime LaunchDate { get; set; }
        public ComicBookType ComicType { get; set; }

        public virtual List<CartItem> CartItems { get; set; }
        public virtual List<OrderComicBook> OrderComicBooks { get; set; }

    }
}
