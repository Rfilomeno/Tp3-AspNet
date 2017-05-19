using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Tp3_AspNet.Data.Context;
using Tp3_AspNet.Domain.Entities;

namespace Tp3_AspNet.Api.Controllers
{
    public class AuthorsController : ApiController
    {
        Context _context;
        public AuthorsController()
        {
            _context = new Context();
        }
        // GET: api/Authors
        public IEnumerable<Author> Get()
        {
            return _context.Authors;
        }
        
        // GET: api/Authors/5
        public Author Get(int id)
        {
            return _context.Authors.Where(a => a.AuthorId == id).FirstOrDefault();
        }

        // POST: api/Authors
        public void Post(Author author)
        {
            if (author != null)
            {
                _context.Authors.Add(author);
                _context.SaveChanges();

            }
        }

        // PUT: api/Authors/5
        public void Put(int id, Author author)
        {
            var busca = _context.Authors.Where(a => a.AuthorId == id).FirstOrDefault();
            if (author != null && busca != null)
            {
                busca = author;
                _context.SaveChanges();
            }
        }

        // DELETE: api/Authors/5
        public void Delete(int id)
        {
            var busca = _context.Authors.Where(a => a.AuthorId == id).FirstOrDefault();
            if (busca != null)
            {
                _context.Authors.Remove(busca);
                _context.SaveChanges();
            }
        }
    }
}
