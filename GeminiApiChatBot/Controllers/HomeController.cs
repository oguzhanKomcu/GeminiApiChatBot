using GeminiApiChatBot.Models;
using GeminiApiChatBot.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace GeminiApiChatBot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGeminiService _geminiService;

        public HomeController(ILogger<HomeController> logger, IGeminiService geminiService)
        {
            _logger = logger;
            _geminiService = geminiService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GeminiChat(string question)
        {
            if (question != null  )
            {
                var prompt = "I want you to edit the Turkish sentence I will give you in accordance with the rules of Turkish grammar and spelling, without compromising the integrity of the meaning. Pay attention to the length and structure of the sentence. If there is a specific grammar rule (e.g. tense harmony, punctuation marks), I want you to focus on that. Your answer must be in Turkish.Here is the Turkish sentence " + "'" + question + "'";
                var response = await _geminiService.GeminiApi(prompt);
                //var response = await _geminiService.GeminiSdk(prompt);//
                return Json(response);
            }
            else
            {
                var errorMessage = "Lütfen bir Türkçe cümle yazınız.";
                return Json(errorMessage);
            }


        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}