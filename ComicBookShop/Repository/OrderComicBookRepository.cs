using ComicBookShop.Context;
using ComicBookShop.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Repository
{
    public class OrderComicBookRepository : GenericRepository<OrderComicBook>, IOrderComicBookRepository
    {
        public OrderComicBookRepository(MySqlContext context) : base(context)
        {

        }
        public List<OrderComicBook> GetOrderComicBooksByOrder(int orderId)
        {
            return _context.OrderComicBooks.Where(oc => oc.OrderId == orderId)
                .Include(oc => oc.ComicBookContained)
                .Include(oc => oc.OrderContaining)
                .ToList();
        }
    }
}
