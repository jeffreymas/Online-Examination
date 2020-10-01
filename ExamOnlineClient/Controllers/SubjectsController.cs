using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ExamOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExamOnlineClient.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44376/api/")
        };
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Load()
        {
            IEnumerable<Subjects> subjectList = null;
            
            var readTask = client.GetAsync("Subjects/");
            readTask.Wait();
            var result = readTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var output = result.Content.ReadAsStringAsync().Result;
                subjectList = JsonConvert.DeserializeObject<List<Subjects>>(output);
            }
            return Json(subjectList);
        }

        public async Task<JsonResult> GetById(string Id)
        {
            Subjects subjects = null;

            var readTask = client.GetAsync("subjects/" + Id);
            readTask.Wait();
            var result = readTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var output = result.Content.ReadAsStringAsync().Result;
                subjects = JsonConvert.DeserializeObject<Subjects>(output);
                
            }
            return Json(subjects);
        }

        public async Task<JsonResult> Insert(string Id, Subjects subjects)
        {
            var item = JsonConvert.SerializeObject(subjects);

            if(Id != null)
            {
                var postTask = client.PutAsync("subjects/" + Id, new StringContent(item, Encoding.UTF8, "application/json"));
                postTask.Wait();
                var result = postTask.Result;
                return Json(new { success = result.IsSuccessStatusCode });
            }
            else
            {
                var postTask = client.PostAsync("subjects", new StringContent(item, Encoding.UTF8, "application/json"));
                postTask.Wait();
                var result = postTask.Result;
                //var oncom = result.Content.ReadAsStringAsync().Result;
                return Json(new { success = result.IsSuccessStatusCode });
            }
        }

        public async Task<JsonResult> Delete(string Id)
        {
            var deleteTask = client.DeleteAsync("subjects/" + Id);
            deleteTask.Wait();

            var result = deleteTask.Result;
            return Json(new { success = result.IsSuccessStatusCode });
        }


    }
}
