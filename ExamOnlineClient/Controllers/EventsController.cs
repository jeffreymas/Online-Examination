using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExamOnline.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Remotion.Linq.Utilities;


namespace ExamOnlineClient.Controllers
{
    public class EventsController : Controller
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
            IEnumerable<Events> eventList = null;
            
            var readTask = client.GetAsync("Events/");
            readTask.Wait();
            var result = readTask.Result;

            if(result.IsSuccessStatusCode)
            {
                var output = result.Content.ReadAsStringAsync().Result;
                eventList = JsonConvert.DeserializeObject<List<Events>>(output);
            }
            return Json(eventList);
        }

        public async Task<JsonResult> GetById(string Id)
        {
            Events events = null;
            var readTask = client.GetAsync("Events/" + Id);
            readTask.Wait();
            var result = readTask.Result;

            if(result.IsSuccessStatusCode)
            {
                var output = result.Content.ReadAsStringAsync().Result;
                events = JsonConvert.DeserializeObject<Events>(output);
                return Json(events);
            }
            return Json(new { result.StatusCode });
        }

        public async Task<JsonResult> Insert(string Id, Events events)
        {
            var item = JsonConvert.SerializeObject(events);

            if(Id != null)
            {
                var postTask = client.PutAsync("events/" + Id, new StringContent(item, Encoding.UTF8, "application/json"));
                postTask.Wait();
                var result = postTask.Result;
                return Json(new { success = result.IsSuccessStatusCode });
            }
            else
            {
                var postTask = client.PostAsync("events", new StringContent(item, Encoding.UTF8, "application/json"));
                postTask.Wait();
                var result = postTask.Result;
                return Json(new { success = result.IsSuccessStatusCode });
            }
        }

        public async Task<JsonResult> Delete(string Id)
        {
            var deleteTask = client.DeleteAsync("events/" + Id);
            deleteTask.Wait();

            var result = deleteTask.Result;
            return Json(new { success = result });
        }

        public async Task<JsonResult> GetEventDetails(string Id)
        {
            HttpContext.Session.SetString("id", Id);
            bool result = true;
            return Json(new { success = result });

        }
    }
}
