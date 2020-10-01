using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ExamOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExamOnlineClient.Controllers
{
    public class QuestionsController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44376/api/")
        };
        public IActionResult Index()
        {
            return View("~/Views/Questions/ManageQuestions.cshtml");
            //if (HttpContext.Session.IsAvailable)
            //{
            //    if (HttpContext.Session.GetString("lvl") == "HR")
            //    {

            //    }
            //    return Redirect("/Error");
            //}
            //return Redirect("/Error");

        }

        [Route("loadGenerate")]
        public IActionResult Generate()
        {
            return View("~/Views/Questions/ExamQuestion.cshtml");
            //if (HttpContext.Session.IsAvailable)
            //{
            //    if (HttpContext.Session.GetString("lvl") == "HR")
            //    {
            //        return View("~/Views/Employees/Approve.cshtml");
            //    }
            //    return Redirect("/Error");
            //}
            //return Redirect("/Error");
        }

        public IActionResult LoadQuestion()
        {
            IEnumerable<Question> question = null;
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("questions");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Question>>();
                readTask.Wait();
                question = readTask.Result; 
            }
            else
            {
                question = Enumerable.Empty<Question>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(question);

        }

        public IActionResult GetById(string Id)
        {
            Question question = null;
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("questions/" + Id);
            resTask.Wait();
            //HttpContext.Session.SetInt32("joblists", Id);
            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                question = JsonConvert.DeserializeObject<Question>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(question);
        }

        public IActionResult InsertOrUpdate(Question question, string id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(question);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var token = HttpContext.Session.GetString("token");
                //client.DefaultRequestHeaders.Add("Authorization", token);
                if (question.Id == null)
                {
                    var result = client.PostAsync("questions", byteContent).Result;
                    return Json(result);
                }
                else if (question.Id == id)
                {
                    var result = client.PutAsync("questions/" + id, byteContent).Result;
                    return Json(result);
                }

                return Json(404);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Delete(string id)
        {
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var result = client.DeleteAsync("questions/" + id).Result;
            return Json(result);
        }



        public IActionResult LoadGen()
        {
            IEnumerable<Question> question = null;
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("answers/generate/");
            //resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Question>>();
                //readTask.Wait();
                question = readTask.Result;
            }
            else
            {
                question = Enumerable.Empty<Question>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(question);

        }

    }
}