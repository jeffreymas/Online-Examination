using ExamOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExamOnlineClient.Views.Examinations
{
    public class ExamPage : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public List<Answer> answ { get; set; }

        [BindProperty(SupportsGet = true)]
        public Answer answer { get; set; }

        private readonly IHttpClientFactory _HttpFac;

        public ExamPage(IHttpClientFactory httpfac)
        {
            _HttpFac = httpfac;
        }


        public async Task<IActionResult> OnGetAsync(int qno)
        {
            var id = "74a050c2-b9db-443e-9331-dbc9242e56bd";
            var apiUrl = "https://localhost:44376/api/examinations/loadsoal/" + id;
            var client = _HttpFac.CreateClient();
            var respond = await client.GetAsync(apiUrl);
            answ = await respond.Content.ReadAsAsync<List<Answer>>();
            answer = answ[qno];
            return Page();
        }

        public IActionResult Submit()
        {
            var a = answer;
            var qno = 2;
            return RedirectToAction("ExamPage", qno);
        }

    }
}
