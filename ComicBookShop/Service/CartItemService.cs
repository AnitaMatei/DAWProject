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
    public class CartItemService : ICartItemService
    {
        private readonly IComicBookRepository comicBookRepository;
        private readonly ICartItemRepository cartItemRepository;
        private readonly AppSettings appSettings;

        public CartItemService(IComicBookRepository comicBookRepository, ICartItemRepository cartItemRepository, IOptions<AppSettings> appSettings)
        {
            this.comicBookRepository = comicBookRepository;
            this.cartItemRepository = cartItemRepository;
            this.appSettings = appSettings.Value;
        }
        public void AddCartItem(User user, string title)
        {
            ComicBook comicBook = comicBookRepository.GetByTitle(title);
            if (comicBook == null)
                throw new HttpResponseException
                {
                    Status = 404
                };
            CartItem cartItem = cartItemRepository.GetItemByUserAndTitle(user, title);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CorrespondingComicBook = comicBook,
                    Quantity = 1,
                    InUsersCart = user
                };
                cartItemRepository.Create(cartItem);
            }
            else
            {
                if (cartItem.IsDeleted)
                {
                    cartItem.Quantity = 1;
                    cartItem.IsDeleted = false;
                }
                else
                    cartItem.Quantity++;
                cartItemRepository.Update(cartItem);
            }

            cartItemRepository.SaveChanges();
        }
        public void IncreaseQuantity(User user, string title)
        {
            CartItem cartItem = cartItemRepository.GetItemByUserAndTitle(user, title);
            if (cartItem == null)
                throw new HttpResponseException
                {
                    Status = 404
                };
            if (cartItem.IsDeleted)
            {
                cartItem.Quantity = 1;
                cartItem.IsDeleted = false;
            }
            else
                cartItem.Quantity++;
            cartItemRepository.Update(cartItem);


            cartItemRepository.SaveChanges();

        }
        public void ReduceQuantity(User user, string title)
        {
            CartItem cartItem = cartItemRepository.GetItemByUserAndTitle(user, title);
            if (cartItem == null)
                throw new HttpResponseException
                {
                    Status = 404
                };
            if (cartItem.Quantity == 1)
                cartItemRepository.HardDelete(cartItem);
            else
            {
                cartItem.Quantity--;
                cartItemRepository.Update(cartItem);
            }

            cartItemRepository.SaveChanges();
        }

        public void RemoveCartItem(User user, string title)
        {
            CartItem cartItem = cartItemRepository.GetItemByUserAndTitle(user, title);
            if (cartItem == null)
                throw new HttpResponseException
                {
                    Status = 404
                };
            cartItemRepository.HardDelete(cartItem);
            cartItemRepository.SaveChanges();
        }
        public List<CartItemResponse> GetPage(User user, int pageNumber, int pageSize)
        {
            var items = cartItemRepository.GetItemsInCartByUser(user, pageNumber, pageSize);

            List<CartItemResponse> response = new List<CartItemResponse>();

            items.ForEach(c =>
            {
                response.Add(new CartItemResponse(c));
            });

            return response;
        }
    }
}