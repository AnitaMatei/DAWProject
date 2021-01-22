using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Model.DTO
{
    public class CartItemResponse
    {
        public CartItemResponse(CartItem cartItem)
        {
            Quantity = cartItem.Quantity;
            CorrespondingComicBook= new ComicBookResponse(cartItem.CorrespondingComicBook);
        }
        public int Quantity { get; set; }

        public virtual ComicBookResponse CorrespondingComicBook { get; set; }
    }
}
