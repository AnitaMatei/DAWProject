using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Model.DTO
{
    public class OrderItemResponse
    {
        public OrderItemResponse(CartItem cartItem)
        {
            Title = cartItem.CorrespondingComicBook.Title;
            Author = cartItem.CorrespondingComicBook.Author;
            CoverUrl = cartItem.CorrespondingComicBook.CoverUrl;
            Price = cartItem.CorrespondingComicBook.Price;
            Quantity = cartItem.Quantity;
        }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverUrl { get; set; }
        public int Price { get; set; }
    }
}
