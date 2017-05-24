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
    public class BooksController : ApiController
    {
        private Context db = new Context();

        // GET: api/Books
        public IList<Book> GetBooks()
        {
            IList<Book> Books = new List<Book>();

            foreach (var books in db.Books.ToList())
            {
                var localBook = new Book()
                {
                    BookId = books.BookId,
                    Titulo = books.Titulo,
                    Isbn = books.Isbn,
                    Authors = new List<Author>()
                };

                foreach (var author in books.Authors)
                {
                    localBook.Authors.Add(new Author()
                    {
                        AuthorId = author.AuthorId,
                        FirstName = author.FirstName,
                        LastName = author.LastName
                    });
                }

                Books.Add(localBook);
            }

            return Books;
            
        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            var query = db.Books.Find(id);
            if (query == null)
            {
                return NotFound();
            }

            var localBook = new Book()
            {
                BookId = query.BookId,
                Titulo = query.Titulo,
                Isbn = query.Isbn,
                Authors = new List<Author>()
            };

            foreach (var author in query.Authors)
            {
                localBook.Authors.Add(new Author()
                {
                    AuthorId = author.AuthorId,
                    FirstName = author.FirstName,
                    LastName = author.LastName
                });
            }

            return Ok(localBook);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.BookId)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.BookId == id) > 0;
        }
    }
}