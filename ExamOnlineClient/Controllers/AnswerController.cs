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
    public class AnswerController : Controller
    {
        private readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44376/api/")
        };

        public IActionResult Index()
        {
            var roleName = HttpContext.Session.GetString("role");
            if (roleName == "Admin" || roleName == "Trainer")
            {
                return View();
            }
            return Redirect("/notfound");
        }

        public async Task<JsonResult> Load()
        {
            List<Answer> answerToView = new List<Answer>();

            //string Id = "b6733b59-eafe-4131-91bf-ab93a4376194";

            string Id = HttpContext.Session.GetString("id");

            List<Answer> answerList = this.LoadAnswer().Result;

            if(answerList != null)
            {
                foreach(var i in answerList)
                {
                    if(i.ExamId == Id)
                    {
                        answerToView.Add(i);
                    }
                }
                return Json(answerToView);
            }
            else
            {
                answerToView = null;
                return Json(answerToView);
            }
        }

        public async Task<List<Answer>> LoadAnswer()
        {
            List<Answer> answers = new List<Answer>();

            var getAPI = client.GetAsync("answers");
            getAPI.Wait();
            var result = getAPI.Result;

            if(result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Answer>>();
                readTask.Wait();
                answers = readTask.Result;
            }
            else
            {
                answers = null;
            }
            return answers;
        }
    }
}
