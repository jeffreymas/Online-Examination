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
    public class NotificationsController : Controller
    {
        private readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44376/api/")
        };
        readonly HttpClient API = new HttpClient
        {
            BaseAddress = new Uri("http://winarto-001-site1.dtempurl.com/api/")
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

        public IActionResult LoadNotif(string id)
        {
            List<EmployeeVM> employees = null;
            List<EmployeeVM> trainees = new List<EmployeeVM>();
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            API.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWToken"));
            var resTask = API.GetAsync("users");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<EmployeeVM>>();
                readTask.Wait();
                employees = readTask.Result;
                foreach (var employee in employees)
                {
                    if (employee.roleName == "Trainee")
                    {
                        trainees.Add(employee);
                    }
                }
            }
            else
            {
                trainees = null;
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }

            id = HttpContext.Session.GetString("id");
            Notifications notifications = null;
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask1 = client.GetAsync("notifications/notif/" + id);
            resTask1.Wait();
            //HttpContext.Session.SetInt32("joblists", Id);
            var result1 = resTask1.Result;
            if (result1.IsSuccessStatusCode)
            {
                var readTask1 = result1.Content.ReadAsAsync<Notifications>();
                readTask1.Wait();

                notifications = readTask1.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            NotificationVM notificationVM = new NotificationVM();
            var trainee = trainees.FirstOrDefault(x => x.id == id);
            notificationVM.nama = trainee.name;
            notificationVM.id = notifications.Id;
            notificationVM.message = notifications.Message;
            notificationVM.createdDate = notifications.CreatedDate;

            return Json(notificationVM);
        }
        public IActionResult Delete(string id)
        {
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var result = client.DeleteAsync("notifications/" + id).Result;
            return Json(result);
        }

    }
}