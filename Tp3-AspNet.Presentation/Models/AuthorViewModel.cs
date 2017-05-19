using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tp3_AspNet.Domain.Entities;

namespace Tp3_AspNet.Presentation.Models
{
    public class AuthorViewModel
    {
        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}