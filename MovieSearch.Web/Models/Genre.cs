using System;
using System.Collections.Generic;

namespace MovieSearch.Web.Models
{
    public partial class Genre
    {
        public Genre()
        {
            TitleGenre = new HashSet<TitleGenre>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TitleGenre> TitleGenre { get; set; }
    }
}
