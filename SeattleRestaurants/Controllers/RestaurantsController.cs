using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeattleRestaurants.Models;
using Microsoft.EntityFrameworkCore;

namespace SeattleRestaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private SeattleRestaurantsContext _db;
        public RestaurantsController(SeattleRestaurantsContext db)
        {
        _db = db;
        }
        // GET api/restaurants
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> Get(string name, string address, string phone, string cuisinetype)
        {
            var query = _db.Restaurants.AsQueryable();
            if (name != null)
            {
                query = _db.Restaurants.Where(entry => entry.Name == name);
            }
            if (address != null)
            {
                query = _db.Restaurants.Where(entry => entry.Address == address);
            }
            if (phone != null)
            {
                query = _db.Restaurants.Where(entry => entry.Phone == phone);
            }
            if (cuisinetype != null)
            {
                query = _db.Restaurants.Where(entry => entry.CuisineType == cuisinetype);
            }
            return query.ToList();
        }

        // GET api/restaurants/5
        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get(int id)
        {
           return _db.Restaurants.FirstOrDefault(entry => entry.RestaurantId == id);
        }

        // POST api/restaurants
        [HttpPost]
        public void Post([FromBody] Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
        }

        // PUT api/restaurants/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Restaurant restaurant)
        {
            restaurant.RestaurantId = id;
            _db.Entry(restaurant).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/restaurants/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var RestaurantToDelete = _db.Restaurants.FirstOrDefault(entry => entry.RestaurantId == id);
            _db.Restaurants.Remove(RestaurantToDelete);
            _db.SaveChanges();
        }
    }
}