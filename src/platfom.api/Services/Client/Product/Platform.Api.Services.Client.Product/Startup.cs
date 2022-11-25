using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Platform.Api.Core.BuildingBlocks.Middlewares;
using Platform.Api.Services.Client.Product.Configuration;
using Platform.Api.Services.Client.Product.Data;
using Platform.Api.Services.Client.Product.Repository;
using Platform.Api.Services.Client.Product.Repository.Abstractions;
using Platform.Api.Services.Client.Product.Services.Abstractions;
using Platform.Api.Services.Client.Product.Services;


public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        AppSettings = new AppSettings();
        Configuration.Bind(AppSettings);
    }

    public IConfiguration Configuration { get; }

    private AppSettings AppSettings { get; set; }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(
                 options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.ReportApiVersions = true;
            setup.RegisterMiddleware = true;
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<ProductDbContext>(options
            => options.UseSqlServer(AppSettings.ConnectionStrings.SQLServer));

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddApiVersioning();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });
        }

        app.UseExceptionHandlerMiddleware();
        app.UseHttpStatusLoggerMiddleware();

        app.UseHttpLogging();

        app.UseApiVersioning();

        app.UseRouting();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.UseHttpsRedirection();
    }
}
