using ComicBookShop.Model.DTO;
using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Service
{
    public interface IOrderService
    {
        OrderResponse CreateOrder(OrderRequest request, User user);
        List<OrderResponse> GetPageOrderedByDate(User user, int pageNumber, int pageSize);
        OrderResponse GetOrderByUUID(User user, string UUID);
    }
}
