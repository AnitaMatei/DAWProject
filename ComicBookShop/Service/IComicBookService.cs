using ComicBookShop.Model.DTO;
using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Service
{
    public interface IComicBookService
    {
        List<ComicBookResponse> GetPage(int pageNumber, int pageSize);
        List<ComicBookResponse> GetPageByName(string name, int pageNumber, int pageSize);
        List<ComicBookResponse> GetPageOrderedByPrice(int pageNumber, int pageSize);
        List<ComicBookResponse> GetPageOrderedByDate(int pageNumber, int pageSize);
        public ComicBookResponse GetByTitle(string title);
    }
}
