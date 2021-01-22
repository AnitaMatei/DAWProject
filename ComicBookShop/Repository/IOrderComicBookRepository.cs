using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Repository
{
    public interface IOrderComicBookRepository : IGenericRepository<OrderComicBook>
    {
        public List<OrderComicBook> GetOrderComicBooksByOrder(int orderId);
    }
}
