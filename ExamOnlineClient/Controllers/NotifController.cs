using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExamOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExamOnlineClient.Controllers
{
    public class NotifController : Controller
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
            IEnumerable<Notifications> notifList = null;

            var readTask = client.GetAsync("notif");
            readTask.Wait();
            var result = readTask.Result;

            if(result.IsSuccessStatusCode)
            {
                var output = result.Content.ReadAsStringAsync().Result;
                notifList = JsonConvert.DeserializeObject<List<Notifications>>(output);
            }
            return Json(notifList);
        }

        public async Task<JsonResult> ReadNotif(string Id)
        {
            var putTask = client.PutAsync("notif/" + Id, new StringContent("application/json"));
            putTask.Wait();
            var result = putTask.Result;
            return Json(new { success = result.StatusCode });

        }


    }
}
