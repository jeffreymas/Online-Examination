using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExamOnline.Models;
using ExamOnlineClient.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExamOnlineClient.Controllers
{
    public class ResultTrainerController : Controller
    {
        List<EmployeeVM> trainees = new List<EmployeeVM>();
        List<EmployeeVM> employeeList = null;

        private readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44376/api/")
        };

        [Route("/resulttrainer")]
        public IActionResult Index()
        {
            var roleName = HttpContext.Session.GetString("role");
            if (roleName == "Trainer" || roleName == "Admin")
            {
                return View();
            }
            return Redirect("/notfound");
        }

        public async Task<JsonResult> Load()
        {
            List<Examination> examList = new List<Examination>();

            IEnumerable<Examination> exam = this.LoadExamination().Result;

            if(exam == null)
            {
                return Json(502);
            }
            else
            {
                foreach(var e in exam)
                {
                    string Id = HttpContext.Session.GetString("id");
                    
                    if(e.EmployeeId == Id)
                    {
                        examList.Add(e);
                    }
                }
                return Json(examList);
            }
        }

        public async Task<IEnumerable<Examination>> LoadExamination()
        {
            IEnumerable<Examination> examnations = null;
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("examinations");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Examination>>();
                readTask.Wait();
                examnations = readTask.Result;
            }
            else
            {
                examnations = Enumerable.Empty<Examination>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return examnations;
        }

        public async Task<JsonResult> GoToAnswers(string Id)
        {
            HttpContext.Session.SetString("id", Id);
            bool result = true;
            return Json(new { success = result });
        }


    }
}

