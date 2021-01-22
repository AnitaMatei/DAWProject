using ComicBookShop.Enum;
using ComicBookShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookShop.Model.DTO
{
    public class ComicBookResponse
    {
        public ComicBookResponse(ComicBook comicBook)
        {
            Title = comicBook.Title;
            Author = comicBook.Author;
            Description = comicBook.Description;
            Genre = comicBook.Genre;
            CoverUrl = comicBook.CoverUrl;
            Price = comicBook.Price;
            LaunchDate = comicBook.LaunchDate;
            ComicType = comicBook.ComicType;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public int Price { get; set; }
        public DateTime LaunchDate { get; set; }
        public ComicBookType ComicType { get; set; }
    }
}
