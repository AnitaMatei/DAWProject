using ComicBookShop.Context;
using ComicBookShop.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Repository
{
    public class CartItemRepository : GenericRepository<CartItem>,ICartItemRepository
    {
        public CartItemRepository(MySqlContext context) : base(context)
        {

        }

        public List<CartItem> GetItemsInCartByUser(User user, int pageNumber, int pageSize)
        {
            var cartItems = _context.CartItems.Where(c => c.InUsersCart == user)
                .Where(c=>c.IsDeleted==false)
                .Include(c => c.CorrespondingComicBook)
                .Skip(pageSize*pageNumber)
                .Take(pageSize)
                .OrderBy(c => c.CreateTime)
                .ToList();
            return cartItems;
        }
        public CartItem GetItemByUserAndTitle(User user, string title)
        {
            var cartItem = _context.CartItems.Where(c => c.CorrespondingComicBook.Title.Contains(title))
                .Where(c => c.InUsersCart == user)
                .Include(c => c.CorrespondingComicBook)
                .FirstOrDefault();
            return cartItem;

        }
    }
}
