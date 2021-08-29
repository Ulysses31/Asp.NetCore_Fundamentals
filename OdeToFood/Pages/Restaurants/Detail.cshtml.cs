using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
	/// <summary>
	/// DetailModel  class
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
	public class DetailModel : PageModel
	{
		/// <summary>
		/// Gets or sets the restaurant.
		/// </summary>
		/// <value>
		/// The restaurant.
		/// </value>
		public Restaurant Restaurant { get; set; }

		/// <summary>
		/// Gets or sets the restaurant data.
		/// </summary>
		/// <value>
		/// The restaurant data.
		/// </value>
		public IRestaurantData restaurantData { get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>
		/// The message.
		/// </value>
		[TempData]
		public string Message { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DetailModel"/> class.
		/// </summary>
		/// <param name="restaurantData">The restaurant data.</param>
		public DetailModel(IRestaurantData restaurantData)
		{
			this.restaurantData = restaurantData;
		}

		/// <summary>
		/// Called when [get].
		/// </summary>
		/// <param name="restaurantId">The restaurant identifier.</param>
		public IActionResult OnGet(int restaurantId)
		{
			Restaurant = restaurantData.GetRestaurantById(restaurantId);

			if (Restaurant == null)
			{
				return RedirectToPage("./NotFound");
			}

			return Page();
		}
	}
}