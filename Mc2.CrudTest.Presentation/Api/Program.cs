
using Project1.Application;
using Project1.Infrastructure;
using Microsoft.Extensions.Options;
using Serilog;

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.Seq("http://localhost:5341")
	.CreateLogger();
try
{
	
	var builder = WebApplication.CreateBuilder(args);
	builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));
	// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

	// Add services to the container.
	builder.Services.AddApplicationServices();
	builder.Services.AddInfrastructureServices(builder.Configuration);
	builder.Services.AddWebUIServices();

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	app.UseSwagger();
	app.UseSwaggerUI();
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
	app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions
	{
		SourceCodeLineCount = 10,
	});

	app.UseHealthChecks("/health");
	app.UseHttpsRedirection();
	
	app.UseStatusCodePages();

	app.UseStaticFiles();

	app.UseRouting();
	app.UseCors("CorsPolicy");
	
	app.MapControllers();

	app.Run();

}
catch (Exception ex)
{
	Log.Fatal(ex, "Unhandled exception");
}
finally
{
	Log.Information("Shut down complete");
	Log.CloseAndFlush();
}