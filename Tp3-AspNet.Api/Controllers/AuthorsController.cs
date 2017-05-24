using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Tp3_AspNet.Data.Context;
using Tp3_AspNet.Domain.Entities;

namespace Tp3_AspNet.Api.Controllers
{
    public class AuthorsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Authors
        public IList<Author> GetAuthors()
        {
            IList<Author> Authors = new List<Author>();

            foreach (var author in db.Authors.ToList())
            {
                var localAuthor = new Author()
                {
                    AuthorId = author.AuthorId,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Books = new List<Book>()
                };

                foreach (var book in author.Books)
                {
                    localAuthor.Books.Add(new Book()
                    {
                        BookId = book.BookId,
                        Titulo = book.Titulo,
                        Isbn = book.Isbn
                    });
                }

                Authors.Add(localAuthor);
            }

            return Authors;

        }
                    

        // GET: api/Authors/5
        [ResponseType(typeof(Author))]
        public IHttpActionResult GetAuthor(int id)
        {
            var query = db.Authors.Find(id);
            if (query == null)
            {
                return NotFound();
            }

            var localAuthor = new Author()
            {
                AuthorId = query.AuthorId,
                FirstName = query.FirstName,
                LastName = query.LastName,
                Books = new List<Book>()
            };

            foreach (var book in query.Books)
            {
                localAuthor.Books.Add(new Book()
                {
                    BookId = book.BookId,
                    Titulo = book.Titulo,
                    Isbn = book.Isbn
                });
            }
            
            return Ok(localAuthor);
        }

        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthor(int id, Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            db.Entry(author).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Authors
        [ResponseType(typeof(Author))]
        public IHttpActionResult PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authors.Add(author);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = author.AuthorId }, author);
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Author))]
        public IHttpActionResult DeleteAuthor(int id)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            db.Authors.Remove(author);
            db.SaveChanges();

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorExists(int id)
        {
            return db.Authors.Count(e => e.AuthorId == id) > 0;
        }
    }
}