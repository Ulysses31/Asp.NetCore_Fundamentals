using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
	/// <summary>
	/// Restaurant class
	/// </summary>
	public class Restaurant
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[Required, StringLength(100)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the location.
		/// </summary>
		/// <value>
		/// The location.
		/// </value>
		[Required, StringLength(100)]
		public string Location { get; set; }

		/// <summary>
		/// Gets or sets the cuisine.
		/// </summary>
		/// <value>
		/// The cuisine.
		/// </value>
		public CuisineType Cuisine { get; set; }
	}
}