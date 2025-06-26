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
                var prompt = $"You are a car buying assistant who helps me choose the best car for my needs. I will provide you with details about a particular car, including the make, model, year of production, fuel type, engine power, mileage, price and other important features. Based on this information, analyze and evaluate the price-performance ratio, market value, fuel efficiency, maintenance costs and long-term benefits. Give me a detailed recommendation on whether I should buy it or not. If there are better alternatives, suggest them as well. Your answer should be logical, analytical and data-driven. Your answer should be accurate and fluent in Turkish. Here are the features of the car I like :" + $" '{question}'";
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