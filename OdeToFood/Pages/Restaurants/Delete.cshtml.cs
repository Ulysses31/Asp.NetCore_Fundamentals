using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
	/// <summary>
	/// DeleteModel class
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
	public class DeleteModel : PageModel
	{
		/// <summary>
		/// The restaurant data
		/// </summary>
		private readonly IRestaurantData restaurantData;

		/// <summary>
		/// Gets or sets the restaurant.
		/// </summary>
		/// <value>
		/// The restaurant.
		/// </value>
		public Restaurant restaurant { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DeleteModel"/> class.
		/// </summary>
		/// <param name="restaurantData">The restaurant data.</param>
		public DeleteModel(IRestaurantData restaurantData)
		{
			this.restaurantData = restaurantData;
		}

		/// <summary>
		/// Called when [get].
		/// </summary>
		/// <param name="restaurantId">The restaurant identifier.</param>
		/// <returns>IActionResult</returns>
		public IActionResult OnGet(int restaurantId)
		{
			restaurant = restaurantData.GetRestaurantById(restaurantId);
			if (restaurant == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
		}

		/// <summary>
		/// Called when [post].
		/// </summary>
		/// <param name="restaurantId">The restaurant identifier.</param>
		/// <returns>IActionResult</returns>
		public IActionResult OnPost(int restaurantId)
		{
			restaurant = restaurantData.Delete(restaurantId);
			if (restaurant == null)
			{
				return RedirectToPage("./NotFound");
			}
			TempData["Message"] = $"{restaurant.Name} deleted.";
			return RedirectToPage("./List");
		}
	}
}