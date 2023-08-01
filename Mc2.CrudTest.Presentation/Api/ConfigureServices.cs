using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Text.Json.Serialization;

public static class ConfigureServices
{
	public static IServiceCollection AddWebUIServices(this IServiceCollection services)
	{

		services.AddControllers()
			.AddNewtonsoftJson(options =>
			{
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
				options.SerializerSettings.ContractResolver = new DefaultContractResolver();
			})
			.AddJsonOptions(option =>
			{
				option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
				option.JsonSerializerOptions.PropertyNamingPolicy = null;
			});
		
		services.AddHttpContextAccessor();
		
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "API",
				Version = "v1.1"
			});
	
			var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
			c.IncludeXmlComments(xmlPath);
		});

		services.AddDistributedMemoryCache();

		services.AddHsts(services =>
		{
			services.MaxAge = TimeSpan.FromDays(365);
			services.IncludeSubDomains = true;
			services.Preload = true;
		});
		services.AddHealthChecks();
		return services;
	}
}
