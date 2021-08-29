using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
	/// <summary>
	/// SqlRestaurantData class
	/// </summary>
	/// <seealso cref="OdeToFood.Data.IRestaurantData" />
	public class SqlRestaurantData : IRestaurantData
	{
		/// <summary>
		/// The database context
		/// </summary>
		private readonly OdeToFoodDbContext db;

		/// <summary>
		/// Initializes a new instance of the <see cref="SqlRestaurantData"/> class.
		/// </summary>
		/// <param name="db">The database.</param>
		public SqlRestaurantData(OdeToFoodDbContext db)
		{
			this.db = db;
		}

		/// <summary>
		/// Adds the specified new restaurant.
		/// </summary>
		/// <param name="newRestaurant">The new restaurant.</param>
		/// <returns>
		/// Restaurant
		/// </returns>
		public Restaurant Add(Restaurant newRestaurant)
		{
			db.Restaurants.Add(newRestaurant);
			db.SaveChanges();
			return newRestaurant;
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
			var entity = db.Restaurants.Attach(updatedRestaurant);
			entity.State = EntityState.Modified;
			db.SaveChanges();
			return updatedRestaurant;
		}

		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		/// Restaurant
		/// </returns>
		public Restaurant Delete(int id)
		{
			var restaurant = GetRestaurantById(id);
			if (restaurant != null)
			{
				db.Restaurants.Remove(restaurant);
				db.SaveChanges();
			}
			return restaurant;
		}

		/// <summary>
		/// Gets the restaurant by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		/// Restaurant
		/// </returns>
		public Restaurant GetRestaurantById(int id)
		{
			return db.Restaurants.Find(id);
		}

		/// <summary>
		/// Gets the name of the restaurants by.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>IEnumerable<Restaurant></returns>
		public IEnumerable<Restaurant> GetRestaurantsByName(string name)
		{
			return from r in db.Restaurants
						 where string.IsNullOrEmpty(name) ||
							r.Name.StartsWith(name)
						 orderby r.Name
						 select r;
		}

		/// <summary>
		/// Gets the count of restaurants.
		/// </summary>
		/// <returns>
		/// int
		/// </returns>
		public int GetCountOfRestaurants()
		{
			return db.Restaurants.Count();
		}
	}
}