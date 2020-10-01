using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExamOnline.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnlineClient.Controllers
{
    public class ResultController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44376/api/")
        };
        readonly HttpClient API = new HttpClient
        {
            BaseAddress = new Uri("http://winarto-001-site1.dtempurl.com/api/")
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoadResult()
        {
            IEnumerable<Examination> examinations = null;
            var id = HttpContext.Session.GetString("id");
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("result/emp/"+ id);
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Examination>>();
                readTask.Wait();
                examinations = readTask.Result;
            }
            else
            {
                examinations = Enumerable.Empty<Examination>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(examinations);

        }
    }
}