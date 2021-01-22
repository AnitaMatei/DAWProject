using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Repository
{
    public interface IComicBookRepository : IGenericRepository<ComicBook>
    {
        public List<ComicBook> GetPage(int pageNumber, int pageSize);
        public List<ComicBook> GetPageByName(string name, int pageNumber, int pageSize);
        List<ComicBook> GetPageOrderedByPrice(int pageNumber, int pageSize);
        List<ComicBook> GetPageOrderedByDate(int pageNumber, int pageSize, int direction);
        public ComicBook GetByTitle(string title);
    }
}
