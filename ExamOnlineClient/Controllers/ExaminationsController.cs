using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ExamOnline.Models;
using ExamOnline.ViewModels;
using ExamOnlineClient.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ExamOnlineClient.Controllers
{
    public class ExaminationsController : Controller 
    {
        public int cek { get; set; }
        public DateTime time { get; set; }
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

        public IActionResult UserIndex()
        {
            return View();
        }
        public IActionResult start(int qno)
        {
            var id = HttpContext.Session.GetString("examid");
            Examination examination = new Examination();
            examination.Id = id;
            examination.ExpiredDate = DateTime.UtcNow.AddSeconds(600);
            InsertOrUpdate(examination,id);
            this.cek = 0;
            var result = StatusCode(200);
            return result;
        }
        public IActionResult ExamPage(int qno)
        {
            if (qno > 9)
            {
                return Redirect("/result");
            }else if(qno < 0)
            {
                qno = 0;
            }

            var direction = ViewBag.direction;
            List<Answer> answ = null;
            ExA ExA = new ExA(); 
            var id = HttpContext.Session.GetString("examid");
            var resTask = client.GetAsync("examinations/loadsoal/" + id);
            resTask.Wait();
            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Answer>>();
                readTask.Wait();
                answ = readTask.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            var answer = answ[qno];
            ExA.Id = answer.Id;
            ExA.QuestionId = answer.QuestionId;
            ExA.Question = answer.Question;
            ExA.Answers = answer.Answers;
            ExA.Status = answer.Status;
            ExA.isDelete = answer.isDelete;
            ExA.ExamId = answer.ExamId;
            ExA.Examination = answer.Examination;
            ExA.QuestionNummber = qno;
            ViewBag.TimeExpired = answer.Examination.ExpiredDate;
            var date1 = DateTime.UtcNow;
            var date2 = answer.Examination.ExpiredDate.Value.AddMinutes(10);
            var date3 = answer.Examination.CreatedDate.UtcDateTime;
            var available = DateTime.Compare(date1 , date2);
            var created = answer.Examination.CreatedDate.UtcDateTime;
            var available2 = DateTime.Compare(date1, created.AddHours(6));
            var available3 = DateTime.Compare(date1, date3);
            if ( available < 0 && available2 < 0 && available3 < 0)
            {
                return View(ExA);
            }
            return Redirect("/result/");
        }

        [HttpPost]
        public IActionResult Submit(ExA ExA)
        {
            var qno = ExA.QuestionNummber + 1;
            Answer answer = new Answer();
            answer.Id = ExA.Id;
            answer.QuestionId = ExA.QuestionId;
            answer.Question = ExA.Question;
            answer.Answers = ExA.Answers;
            answer.Status = ExA.Status;
            answer.isDelete = ExA.isDelete;
            answer.ExamId = ExA.ExamId;
            answer.Examination = ExA.Examination;
            var json = JsonConvert.SerializeObject(answer);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PutAsync("answers/" + answer.Id, byteContent).Result;

            return RedirectToAction("ExamPage", new{@qno = qno});
        }
        public IActionResult ShowReschedule()
        {
            return View();
        }

        public IActionResult LoadEmployee()
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
            return Json(trainees);
        }
        public IActionResult LoadExamination()
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
            return Json(examnations);

        }

        public IActionResult GetById(string Id)
        {
            Examination examination = null;
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("examinations/" + Id);
            resTask.Wait();
            //HttpContext.Session.SetInt32("joblists", Id);
            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                examination = JsonConvert.DeserializeObject<Examination>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(examination);
        }

        public IActionResult InsertOrUpdate(Examination examination, string id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(examination);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var token = HttpContext.Session.GetString("token");
                //client.DefaultRequestHeaders.Add("Authorization", token);
                if (examination.Id == null)
                {
                    var result = client.PostAsync("examinations", byteContent).Result;
                    return Json(result);
                }
                else if (examination.Id != null)
                {
                    var result = client.PutAsync("examinations/" + id, byteContent).Result;
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
            var result = client.DeleteAsync("examinations/" + id).Result;
            return Json(result);
        }

        public ActionResult GetUser()
        {
            var id = HttpContext.Session.GetString("id");
            Examination examination = null;

            var resTask = client.GetAsync("examinations/details/" + id);
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Examination>();
                readTask.Wait();

                examination = readTask.Result;
                HttpContext.Session.SetString("examid", examination.Id);

            }
            var response = Tuple.Create(examination, result);

            return Json(response, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public IActionResult Reschedule(Examination examination, string id)
        {
            var ids = HttpContext.Session.GetString("id");
            Examination examinationn = null;
            var resTask = client.GetAsync("examinations/details/" + ids);
            resTask.Wait();
            var resultt = resTask.Result;
            if (resultt.IsSuccessStatusCode)
            {
                var readTask = resultt.Content.ReadAsAsync<Examination>();
                readTask.Wait();

                examinationn = readTask.Result;
                examinationn.RescheduleDate = examination.RescheduleDate;
            }
            id = examinationn.Id;

            try
            {
                var json = JsonConvert.SerializeObject(examinationn);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client.PutAsync("examinations/reschedule/" + id, byteContent).Result;
                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult readSchedule()
        {
            IEnumerable<Examination> emp = null;
            //var token = HttpContext.Session.GetString("token");
            //client.DefaultRequestHeaders.Add("Authorization", token);
            var resTask = client.GetAsync("reschedule");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Examination>>();
                readTask.Wait();
                emp = readTask.Result;
            }
            else
            {
                emp = Enumerable.Empty<Examination>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(emp);
        }

        public IActionResult Approve(Examination examination)
        {
            var json = JsonConvert.SerializeObject(examination);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage result = null;
            if (examination.Id != null)
            {
                result = client.PostAsync("reschedule/Approve/", byteContent).Result;
                return Json(result);
            }
            return Json(404);
        }

        public IActionResult Reject(Examination examination)
        {
            var json = JsonConvert.SerializeObject(examination);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage result = null;
            if (examination.Id != null)
            {
                result = client.PostAsync("reschedule/Reject/", byteContent).Result;
                return Json(result);
            }
            return Json(404);
        }
    }
}