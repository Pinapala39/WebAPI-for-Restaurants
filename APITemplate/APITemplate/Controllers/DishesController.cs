using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITemplate.Models;
using APITemplate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITemplate.Controllers
{
    [Produces("application/json")]
    [Route("api/Dishes")]
    public class DishesController : Controller
    {

        // GET: api/Dishes
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var mongoDBService = new MongoDBService("Restaurant", "Dishes", "mongodb://localhost:27017");
            var allDishes = await mongoDBService.GetDishes();

            return Json(allDishes);
        }
        
        // POST: api/Dishes
        [HttpPost]
        public async Task Post([FromBody]Dishes dishes)
        {
            var mongoDBService = new MongoDBService("Restaurant", "Dishes", "mongodb://localhost:27017");
          await mongoDBService.InsertDish(dishes);
            
        }
        
        // PUT: api/Dishes/5
        //[HttpPut("{id}")]
        //public async Task<string> Put(string id, [FromBody]Dishes dishes)
        //{
        //        var mongoDBService = new MongoDBService("Restaurant", "Dishes", "mongodb://localhost:27017");
        //    return await mongoDBService.Update(id, dishes);
        //}
        
    }
}
