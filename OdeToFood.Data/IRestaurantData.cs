using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
	/// <summary>
	/// IRestaurantData interface
	/// </summary>
	public interface IRestaurantData
	{
		/// <summary>
		/// Gets the restaurants by name.
		/// </summary>
		/// <param name="name">The restaurant name.</param>
		/// <returns>IEnumerable<Restaurant></returns>
		IEnumerable<Restaurant> GetRestaurantsByName(string name);

		/// <summary>
		/// Gets the restaurant by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Restaurant</returns>
		Restaurant GetRestaurantById(int id);

		/// <summary>
		/// Updates the specified restaurant.
		/// </summary>
		/// <param name="updatedRestaurant">The updated restaurant.</param>
		/// <returns>Restaurant</returns>
		Restaurant Update(Restaurant updatedRestaurant);

		/// <summary>
		/// Adds the specified new restaurant.
		/// </summary>
		/// <param name="newRestaurant">The new restaurant.</param>
		/// <returns>Restaurant</returns>
		Restaurant Add(Restaurant newRestaurant);

		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Restaurant</returns>
		Restaurant Delete(int id);

		/// <summary>
		/// Gets the count of restaurants.
		/// </summary>
		/// <returns>int</returns>
		int GetCountOfRestaurants();
	}
}