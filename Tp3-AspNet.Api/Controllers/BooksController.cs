using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tp3_AspNet.Data.Context;
using Tp3_AspNet.Domain.Entities;

namespace Tp3_AspNet.Api.Controllers
{
    public class BooksController : ApiController
    {
        Context _context;
        public BooksController()
        {
            _context = new Context();
        }
        // GET api/Books
        public IEnumerable<Book> Get()
        {
            return _context.Books;
        }

        // GET api/Books/5
        public Book Get(int id)
        {
            return _context.Books.Where(b => b.BookId == id).FirstOrDefault();
        }

        // POST api/Books
        public void Post(Book book)
        {
            if (book != null)
            {
                _context.Books.Add(book);
                _context.SaveChanges();

            }
        }

        // PUT api/Books/5
        public void Put(int id, Book book)
        {
            var busca = _context.Books.Where(b => b.BookId == id).FirstOrDefault();
            if (book != null && busca != null)
            {
                busca = book;
                _context.SaveChanges();
            }
        }

        // DELETE api/Books/5
        public void Delete(int id)
        {
            var busca = _context.Books.Where(b => b.BookId == id).FirstOrDefault();
            if (busca != null)
            {
                _context.Books.Remove(busca);
                _context.SaveChanges();

            }
        }
    }
}