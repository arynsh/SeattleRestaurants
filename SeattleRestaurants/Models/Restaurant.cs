using System;

namespace SeattleRestaurants.Models
{
    public class Restaurant
    {
       public int RestaurantId { get; set; }
       public string Name { get; set; }
       public string Address { get; set; }
       public string Phone { get; set; }
       public string CuisineType { get; set; }
    }
}
