using ComicBookShop.Exceptions;
using ComicBookShop.Model;
using ComicBookShop.Model.DTO;
using ComicBookShop.Model.Entity;
using ComicBookShop.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUserRepository userRepository;
        private readonly IOrderRepository orderRepository;
        private readonly ICartItemRepository cartItemRepository;
        private readonly IOrderComicBookRepository orderComicBookRepository;
        private readonly AppSettings appSettings;

        public OrderService(IUserRepository userRepository,IOrderRepository orderRepository, ICartItemRepository cartItemRepository, IOrderComicBookRepository orderComicBookRepository, IOptions<AppSettings> appSettings)
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
            this.cartItemRepository = cartItemRepository;
            this.orderComicBookRepository = orderComicBookRepository;
            this.appSettings = appSettings.Value;
        }
        public OrderResponse CreateOrder(OrderRequest request, User user)
        {

            if (user.DeliveryAddress == null)
                throw new HttpResponseException
                {
                    Status = 400
                };


            var order = new Order
            {
                UUID = Guid.NewGuid().ToString().Replace("-", ""),
                Details = request.Details,
                DeliveryAddress = user.DeliveryAddress,
                OrderedByUser = user
            };
            orderRepository.Create(order);
            orderRepository.SaveChanges();

            List<OrderComicBook> orderComicBooks = new List<OrderComicBook>();
            int totalPrice = 0;
            cartItemRepository.GetItemsInCartByUser(user,0, 100).ForEach(
                c =>
                {
                    var orderItem = new OrderComicBook { OrderContaining = order, ComicBookContained = c.CorrespondingComicBook };
                    totalPrice += c.CorrespondingComicBook.Price * c.Quantity;
                    orderComicBooks.Add(orderItem);
                    cartItemRepository.Delete(c);
                }
               );
            order.TotalPrice = totalPrice;
            orderComicBookRepository.CreateRange(orderComicBooks);
            orderComicBookRepository.SaveChanges();
            cartItemRepository.SaveChanges();


            return new OrderResponse(order);
        }
        public List<OrderResponse> GetPageOrderedByDate(User user, int pageNumber, int pageSize)
        {
            var orders = orderRepository.GetOrdersByUser(user, pageSize, pageNumber);
            List<OrderResponse> response = new List<OrderResponse>();
            orders.ForEach(o =>
            {
                o.OrderComicBooks = orderComicBookRepository.GetOrderComicBooksByOrder(o.Id);
                response.Add(new OrderResponse(o));
            });

            return response;
        }
        public OrderResponse GetOrderByUUID(User user, string UUID)
        {
            var order = orderRepository.GetOrderByUserAndUUID(user, UUID);
            if (order == null)
                throw new HttpResponseException
                {
                    Status = 401
                };
            order.OrderComicBooks = orderComicBookRepository.GetOrderComicBooksByOrder(order.Id);

            return new OrderResponse(order);
        }
    }
}
