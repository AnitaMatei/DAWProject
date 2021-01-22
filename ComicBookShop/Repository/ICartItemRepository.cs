using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Repository
{
    public interface ICartItemRepository: IGenericRepository<CartItem>
    {
        List<CartItem> GetItemsInCartByUser(User user, int pageNumber, int pageSize);
        CartItem GetItemByUserAndTitle(User user, string title);
    }
}
