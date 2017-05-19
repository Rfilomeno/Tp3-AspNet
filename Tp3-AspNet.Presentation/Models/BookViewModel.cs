using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tp3_AspNet.Domain.Entities;

namespace Tp3_AspNet.Presentation.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        public string Titulo { get; set; }

        public string Isbn { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}