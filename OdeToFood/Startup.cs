using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdeToFood.Data;

namespace OdeToFood
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContextPool<OdeToFoodDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb"));
			});

			// CORS
			services.AddCors(options => {
				options.AddPolicy("DevCorsPolicy", builder => {
					builder
							.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader()
							.SetIsOriginAllowed(origin => true);
				});
			});

			services.AddScoped<IRestaurantData, SqlRestaurantData>();
			//services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts(); // secure connection https
			}

			app.UseHttpsRedirection();
			
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseCookiePolicy();

			app.UseCors("DevCorsPolicy");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
			});
		}
	}
}