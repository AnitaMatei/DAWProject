using ComicBookShop.Context;
using ComicBookShop.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Repository
{
    public class ComicBookRepository : GenericRepository<ComicBook>, IComicBookRepository
    {
        public ComicBookRepository(MySqlContext context) : base(context)
        {

        }
        public List<ComicBook> GetPage(int pageNumber, int pageSize)
        {
            var comicbooks = _context.ComicBooks
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToList();

            return comicbooks;
        }
        public List<ComicBook> GetPageByName(string name, int pageNumber, int pageSize)
        {
            var comicbooks = _context.ComicBooks.Where(c => c.Title.Contains(name))
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToList();

            return comicbooks;
        }
        public List<ComicBook> GetPageOrderedByPrice(int pageNumber, int pageSize)
        {
            var comicbooks = _context.ComicBooks
                .OrderBy(c => c.Price)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToList();

            return comicbooks;

        }
        public List<ComicBook> GetPageOrderedByDate(int pageNumber, int pageSize, int direction)
        {
            List<ComicBook> comicbooks;

            if (direction == 1)
                comicbooks = _context.ComicBooks
                    .OrderBy(c => c.LaunchDate)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToList();
            else comicbooks = _context.ComicBooks
                    .OrderByDescending(c => c.LaunchDate)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToList();

            return comicbooks;

        }
        public ComicBook GetByTitle(string title)
        {
            ComicBook comicBook = _context.ComicBooks
                .Where(c => c.Title.Equals(title))
                .FirstOrDefault();

            return comicBook;
        }
    }
}
