using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicBookShop.Model.Entity;

namespace ComicBookShop.Model.Entity
{
    public class OrderComicBook : BaseEntity
    {
        public int OrderId { get; set; }
        public int ComicBookId { get; set; }

        public virtual Order OrderContaining { get; set; }
        public virtual ComicBook ComicBookContained { get; set; }
    }
}
