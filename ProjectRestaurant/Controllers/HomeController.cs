using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APITemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectRestaurant.Helper;
using ProjectRestaurant.Models;

namespace ProjectRestaurant.Controllers
{
    public class HomeController : Controller
    {
        DishesAPI _api = new DishesAPI();
        public async Task<IActionResult> Index()
        {
            List<Dishes> dishes = new List<Dishes>();
            HttpClient client = _api.Initial();
            HttpResponseMessage httpResponseMessage = await client.GetAsync("api/Dishes");
            if(httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                dishes = JsonConvert.DeserializeObject<List<Dishes>>(result);
            }
            return View(dishes);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
