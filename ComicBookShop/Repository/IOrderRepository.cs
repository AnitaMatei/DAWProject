using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        List<Order> GetOrdersByUser(User user, int pageSize, int pageNumber);
        Order GetOrderByUserAndUUID(User user, string uuid);
    }
}
