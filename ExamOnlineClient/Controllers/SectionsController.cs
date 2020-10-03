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
    public class SectionsController : Controller
    {
        private readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44376/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadSection()
        {
            IEnumerable<Section> sections = null;
            var resTask = client.GetAsync("sections");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Section>>();
                readTask.Wait();
                sections = readTask.Result;
            }
            else
            {
                sections = Enumerable.Empty<Section>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(sections);

        }

        public IActionResult GetById(string Id)
        {
            Section sections = null;
            var resTask = client.GetAsync("sections/" + Id);
            resTask.Wait();
            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                sections = JsonConvert.DeserializeObject<Section>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(sections);
        }

        public IActionResult InsertOrUpdate(Section sections, string id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(sections);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var token = HttpContext.Session.GetString("token");
                //client.DefaultRequestHeaders.Add("Authorization", token);
                if (sections.Id == null)
                {
                    var result = client.PostAsync("sections", byteContent).Result;
                    return Json(result);
                }
                else if (sections.Id == id)
                {
                    var result = client.PutAsync("sections/" + id, byteContent).Result;
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
            var result = client.DeleteAsync("sections/" + id).Result;
            return Json(result);
        }
    }
}