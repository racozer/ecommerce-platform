using System.Text.Json.Serialization;

using Microsoft.EntityFrameworkCore;

using Platform.Api.Core.BuildingBlocks.Middlewares;
using Platform.Api.Services.Client.Product.Configuration;
using Platform.Api.Services.Client.Product.Data;


public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
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
        services.AddSwaggerGen();

        // services.AddDbContext<ProductDbContext>(options
        //      => options.UseSqlServer(builder.Configuration["ConnectionStrings:SQLServer"]));
        services.AddEndpointsApiExplorer();

        services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(AppSettings.ConnectionStrings.SQLServer));

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();
    }
}
