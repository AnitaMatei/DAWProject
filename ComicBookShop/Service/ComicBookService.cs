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
    public class ComicBookService : IComicBookService
    {
        private readonly IComicBookRepository comicBookRepository;
        private readonly AppSettings appSettings;

        public ComicBookService(IComicBookRepository comicBookRepository, IOptions<AppSettings> appSettings)
        {
            this.comicBookRepository = comicBookRepository;
            this.appSettings = appSettings.Value;
        }
        public List<ComicBookResponse> GetPage(int pageNumber, int pageSize)
        {
            List<ComicBookResponse> response = new List<ComicBookResponse>();
            comicBookRepository.GetPage(pageNumber, pageSize).ForEach(
                c =>
                {
                    response.Add(new ComicBookResponse(c));
                }
                );
            return response;

        }

        public List<ComicBookResponse> GetPageByName(string name, int pageNumber, int pageSize)
        {
            List<ComicBookResponse> response = new List<ComicBookResponse>();
            comicBookRepository.GetPageByName(name, pageNumber, pageSize).ForEach(
                c =>
                {
                    response.Add(new ComicBookResponse(c));
                }
                );
            return response;
        }
        public List<ComicBookResponse> GetPageOrderedByPrice(int pageNumber, int pageSize)
        {
            List<ComicBookResponse> response = new List<ComicBookResponse>();
            comicBookRepository.GetPageOrderedByPrice(pageNumber, pageSize).ForEach(
                c =>
                {
                    response.Add(new ComicBookResponse(c));
                }
                );
            return response;
        }
        public List<ComicBookResponse> GetPageOrderedByDate(int pageNumber, int pageSize)
        {
            List<ComicBookResponse> response = new List<ComicBookResponse>();
            comicBookRepository.GetPageOrderedByDate(pageNumber, pageSize, 0).ForEach(
                c =>
                {
                    response.Add(new ComicBookResponse(c));
                }
                );
            return response;
        }
        public ComicBookResponse GetByTitle(string title)
        {
            var comicbook = comicBookRepository.GetByTitle(title);
            if (comicbook == null)
                throw new HttpResponseException
                {
                    Status = 401
                };
            return new ComicBookResponse(comicbook);
        }
    }
}
