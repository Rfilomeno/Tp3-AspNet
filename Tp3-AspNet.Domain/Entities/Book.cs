using System.Collections.Generic;

namespace Tp3_AspNet.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }

        public string Titulo { get; set; }

        public string Isbn { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
