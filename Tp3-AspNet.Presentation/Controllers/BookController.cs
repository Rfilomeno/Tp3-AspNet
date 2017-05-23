using Newtonsoft.Json;
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
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("http://localhost:53997/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Books").Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var BookVM = JsonConvert.DeserializeObject<List<BookViewModel>>(JsonString);
                    return View(BookVM);

                }
                return View();
            }
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("http://localhost:53997/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Books/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var BookVM = JsonConvert.DeserializeObject<BookViewModel>(JsonString);
                    return View(BookVM);

                }
                return View();

            }
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public async Task<ActionResult> Create(Book book)
        {
            try
            {
                using (var apiClient = new HttpClient())
                {
                    var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                    apiClient.BaseAddress = new Uri("http://localhost:53997/");
                    apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                    var resposta = await apiClient.PostAsJsonAsync("/api/Books", book);

                    return RedirectToAction("Index");

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("http://localhost:53997/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Books/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var BookVM = JsonConvert.DeserializeObject<BookViewModel>(JsonString);
                    return View(BookVM);

                }
                return View();
            }
        }

        // POST: Book/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, BookViewModel BookVM)
        {
            try
            {
                using (var apiClient = new HttpClient())
                {
                    var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                    apiClient.BaseAddress = new Uri("http://localhost:53997/");
                    apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                    var resposta = await apiClient.PutAsJsonAsync("/api/Books/" + id, BookVM);

                    return RedirectToAction("Index");

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                apiClient.BaseAddress = new Uri("http://localhost:53997/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = apiClient.GetAsync("/api/Books/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = response.Content.ReadAsStringAsync().Result;
                    var BookVM = JsonConvert.DeserializeObject<BookViewModel>(JsonString);
                    return View(BookVM);

                }
                return View();
            }
        }

        // POST: Book/Delete/5
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
                    var resposta = await apiClient.DeleteAsync("/api/Books/" + id);

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
