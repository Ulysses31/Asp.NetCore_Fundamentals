using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
	/// <summary>
	/// RestaurantCountViewComponent class
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ViewComponent" />
	public class RestaurantCountViewComponent : ViewComponent
	{
		/// <summary>
		/// The restaurant data
		/// </summary>
		private readonly IRestaurantData restaurantData;

		/// <summary>
		/// Initializes a new instance of the <see cref="RestaurantCountViewComponent"/> class.
		/// </summary>
		/// <param name="restaurantData">The restaurant data.</param>
		public RestaurantCountViewComponent(IRestaurantData restaurantData)
		{
			this.restaurantData = restaurantData;
		}

		/// <summary>
		/// Invokes this instance.
		/// </summary>
		/// <returns>IViewComponentResult</returns>
		public IViewComponentResult Invoke()
		{
			var count = restaurantData.GetCountOfRestaurants();
			return View(count);
		}
	}
}