using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tp3_AspNet.Domain.Entities;
using Tp3_AspNet.Presentation.Models;

namespace Tp3_AspNet.Presentation.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            using(var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("http://localhost:53997/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Authors").Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var authorsVM = JsonConvert.DeserializeObject<List<AuthorViewModel>>(JsonString);

                    return View(authorsVM);

                }
                return View();
            }
            
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("http://localhost:53997/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Authors/"+id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var authorVM = JsonConvert.DeserializeObject<AuthorViewModel>(JsonString);
                    return View(authorVM);

                }
                return View();

            }
            
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public async Task<ActionResult> Create(Author author)
        {
            try
            {
                using (var apiClient = new HttpClient())
                {
                    var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                    apiClient.BaseAddress = new Uri("http://localhost:53997/");
                    apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                    var resposta = await apiClient.PostAsJsonAsync("/api/Authors", author);
                    
                    return RedirectToAction("Index");

                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("http://localhost:53997/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Authors/" + id).Result;
                var response2 = apiClient.GetAsync("/api/Books/").Result;
                if (response2.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var BooksVM = JsonConvert.DeserializeObject<List<BookViewModel>>(JsonString);
                    
                }
                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var authorVM = JsonConvert.DeserializeObject<AuthorViewModel>(JsonString);
                    return View(authorVM);

                }
                return View();

            }
            
        }

        // POST: Author/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, AuthorViewModel authorvm)
        {

            Author author = new Author()
            {
                AuthorId = authorvm.AuthorId,
                FirstName = authorvm.FirstName,
                LastName = authorvm.LastName,
                Books = authorvm.Books
            };

            try
            {
                using (var apiClient = new HttpClient())
                {
                    var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                    apiClient.BaseAddress = new Uri("http://localhost:53997/");
                    apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                    var resposta = await apiClient.PutAsJsonAsync("/api/Authors/"+id, author);
                    
                    return RedirectToAction("Index");

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("http://localhost:53997/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Authors/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var authorVM = JsonConvert.DeserializeObject<AuthorViewModel>(JsonString);
                    return View(authorVM);

                }
                return View();

            }
        }

        // POST: Author/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                using (var apiClient = new HttpClient())
                {
                    var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                    apiClient.BaseAddress = new Uri("http://localhost:53997/");
                    apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                    var resposta = await apiClient.DeleteAsync("/api/Authors/" + id);

                    return RedirectToAction("Index");

                }
            }
            catch
            {
                return View();
            }
        }
    }
}
