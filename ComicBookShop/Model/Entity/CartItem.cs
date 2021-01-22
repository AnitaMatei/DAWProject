using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Model.Entity
{
    public class CartItem : BaseEntity
    {
        public int Quantity { get; set; }

        public virtual ComicBook CorrespondingComicBook { get; set; }
        public virtual User? InUsersCart { get; set; }
    }
}
