using ComicBookShop.Context;
using ComicBookShop.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(MySqlContext context) : base(context)
        {

        }


        public List<Order> GetOrdersByUser(User user, int pageSize, int pageNumber)
        {
            var orders = _context.Orders.Where(o => o.OrderedByUser == user)
                .Include(o => o.OrderComicBooks)
                .Include(o => o.DeliveryAddress)
                .OrderByDescending(o => o.CreateTime)
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToList();
            return orders;
        }
        public Order GetOrderByUserAndUUID(User user, string uuid)
        {
            var order = _context.Orders.Where(o => o.OrderedByUser == user)
                .Where(o => o.UUID.Equals(uuid))
                .Include(o => o.OrderComicBooks)
                .Include(o => o.DeliveryAddress)
                .FirstOrDefault();

            return order;
        }
    }
}
