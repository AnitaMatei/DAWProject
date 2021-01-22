using ComicBookShop.Model.DTO;
using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Service
{
    public interface ICartItemService
    {
        public void AddCartItem(User user, string title);
        public void IncreaseQuantity(User user, string title);
        public void ReduceQuantity(User user, string title);
        public void RemoveCartItem(User user, string title);
        public List<CartItemResponse> GetPage(User user, int pageNumber, int pageSize);
    }
}