using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Model.DTO
{
    public class OrderResponse
    {
        public OrderResponse(Order order)
        {
            UUID = order.UUID;
            Details = order.Details;
            ComicBookResponses = new List<ComicBookResponse>();
            order.OrderComicBooks.ForEach(
                c =>
                {
                    ComicBookResponses.Add(new ComicBookResponse(c.ComicBookContained));
                });
            DeliveryAddress = new AddressResponse(order.DeliveryAddress);
            TotalPrice = order.TotalPrice;
            CreateDate = order.CreateTime;
        }
        public DateTime CreateDate { get; set; }
        public int TotalPrice { get; set; }
        public string UUID { get; set; }
        public string Details { get; set; }
        public virtual List<ComicBookResponse> ComicBookResponses { get; set; }
        public virtual AddressResponse DeliveryAddress { get; set; }
    }
}
