using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
	/// <summary>
	/// ListModel class
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
	public class ListModel : PageModel
	{
		/// <summary>
		/// The configuration
		/// </summary>
		private readonly IConfiguration config;

		/// <summary>
		/// The restaurant data
		/// </summary>
		private readonly IRestaurantData restaurantData;

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>
		/// The message.
		/// </value>
		public string AppSettingsMessage { get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>
		/// The message.
		/// </value>
		[TempData]
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the restaurants.
		/// </summary>
		/// <value>
		/// The restaurants.
		/// </value>
		public IEnumerable<Restaurant> Restaurants { get; set; }

		/// <summary>
		/// Gets or sets the search term.
		/// </summary>
		/// <value>
		/// The search term.
		/// </value>
		[BindProperty(SupportsGet = true)]
		public string SearchTerm { get; set; }


		/// <summary>
		/// Initializes a new instance of the <see cref="ListModel"/> class.
		/// </summary>
		/// <param name="config">The configuration.</param>
		/// <param name="restaurantData">The restaurant data.</param>
		public ListModel(
			IConfiguration config, 
			IRestaurantData restaurantData
		)
		{
			this.config = config;
			this.restaurantData = restaurantData;
		}

		/// <summary>
		/// Called when [get].
		/// </summary>
		public void OnGet()
		{
			AppSettingsMessage = config["Message"];
			Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
		}
	}
}