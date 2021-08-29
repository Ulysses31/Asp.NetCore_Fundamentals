using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
	/// <summary>
	/// InMemoryRestaurantData class
	/// </summary>
	/// <seealso cref="OdeToFood.Data.IRestaurantData" />
	public class InMemoryRestaurantData : IRestaurantData
	{
		/// <summary>
		/// The restaurants
		/// </summary>
		private readonly List<Restaurant> restaurants;

		/// <summary>
		/// Initializes a new instance of the <see cref="InMemoryRestaurantData"/> class.
		/// </summary>
		public InMemoryRestaurantData()
		{
			restaurants = new List<Restaurant>()
			{
				new Restaurant() {
					Id = 1,
					Name = "Scott's Pizza",
					Location = "Maryland",
					Cuisine = CuisineType.Italian
				},
				new Restaurant() {
					Id = 2,
					Name = "Cinnamon Club",
					Location = "London",
					Cuisine = CuisineType.Italian
				},
				new Restaurant() {
					Id = 3,
					Name = "La Costa",
					Location = "California",
					Cuisine = CuisineType.Mexican
				}
			};
		}

		/// <summary>
		/// Gets the restaurant by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public Restaurant GetRestaurantById(int id)
		{
			return restaurants.SingleOrDefault(r => r.Id == id);
		}

		/// <summary>
		/// Get all restaurants.
		/// </summary>
		/// <returns>IEnumerable<Restaurant></returns>
		public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
		{
			return from r in restaurants
						 where string.IsNullOrEmpty(name) ||
							r.Name.ToLowerInvariant().StartsWith(name)
						 orderby r.Name
						 select r;
		}

		/// <summary>
		/// Updates the specified restaurant.
		/// </summary>
		/// <param name="updatedRestaurant">The updated restaurant.</param>
		/// <returns>
		/// Restaurant
		/// </returns>
		public Restaurant Update(Restaurant updatedRestaurant)
		{
			var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
			if (restaurant != null)
			{
				restaurant.Name = updatedRestaurant.Name;
				restaurant.Location = updatedRestaurant.Location;
				restaurant.Cuisine = updatedRestaurant.Cuisine;
			}

			return restaurant;
		}

		/// <summary>
		/// Adds the specified new restaurant.
		/// </summary>
		/// <param name="newRestaurant">The new restaurant.</param>
		/// <returns>Restaurant</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public Restaurant Add(Restaurant newRestaurant)
		{
			restaurants.Add(newRestaurant);
			newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
			return newRestaurant;
		}

		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		/// Restaurant
		/// </returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public Restaurant Delete(int id)
		{
			var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
			if (restaurant != null)
			{
				restaurants.Remove(restaurant);
			}
			return restaurant;
		}

		/// <summary>
		/// Gets the count of restaurants.
		/// </summary>
		/// <returns>
		/// int
		/// </returns>
		public int GetCountOfRestaurants()
		{
			return restaurants.Count;
		}
	}
}