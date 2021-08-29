using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
	/// <summary>
	/// EditModel class
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
	public class EditModel : PageModel
	{
		/// <summary>
		/// Gets or sets the restaurant data.
		/// </summary>
		/// <value>
		/// The restaurant data.
		/// </value>
		private readonly IRestaurantData restaurantData;

		/// <summary>
		/// The HTML helper
		/// </summary>
		private readonly IHtmlHelper htmlHelper;

		/// <summary>
		/// Gets or sets the restaurant.
		/// </summary>
		/// <value>
		/// The restaurant.
		/// </value>
		[BindProperty]
		public Restaurant Restaurant { get; set; }

		/// <summary>
		/// Gets or sets the cuisines.
		/// </summary>
		/// <value>
		/// The cuisines.
		/// </value>
		public IEnumerable<SelectListItem> Cuisines { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="EditModel"/> class.
		/// </summary>
		/// <param name="restaurantData">The restaurant data.</param>
		public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
		{
			this.restaurantData = restaurantData;
			this.htmlHelper = htmlHelper;
		}

		/// <summary>
		/// Called when [get].
		/// </summary>
		public IActionResult OnGet(int? restaurantId)
		{
			Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

			if (restaurantId.HasValue)
			{
				Restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
			}
			else
			{
				Restaurant = new Restaurant();
			}

			if (Restaurant == null)
			{
				return RedirectToPage("./NotFound");
			}

			return Page();
		}

		/// <summary>
		/// Called when [post].
		/// </summary>
		/// <returns>IActionResult</returns>
		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
				return Page();
			}

			if (Restaurant.Id > 0)
			{
				// Update
				Restaurant = restaurantData.Update(Restaurant);
			}
			else
			{
				// Insert
				Restaurant = restaurantData.Add(Restaurant);
			}
			TempData["Message"] = "Restaurant saved!";
			return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
		}
	}
}