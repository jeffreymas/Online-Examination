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
            BaseAddress = new Uri("http://winarto-001-site1.dtempurl.com/api/exams/")
        };
        public IActionResult Index()
        {

            var roleName = HttpContext.Session.GetString("role");
            if (roleName == "Trainee")
            {
                return View();
            }
            return Redirect("/notfound");
        }

        [Route("ExamResult")]
        public IActionResult Resultex()
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
        public IActionResult ExResult()
        {
            var id = HttpContext.Session.GetString("id");
            Examination examination = null;
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask1 = client.GetAsync("examinations/details/" + id);
            resTask1.Wait();
            //HttpContext.Session.SetInt32("joblists", Id);
            var result1 = resTask1.Result;
            if (result1.IsSuccessStatusCode)
            {
                var readTask1 = result1.Content.ReadAsAsync<Examination>();
                readTask1.Wait();

                examination = readTask1.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(examination);
        }
    }
}