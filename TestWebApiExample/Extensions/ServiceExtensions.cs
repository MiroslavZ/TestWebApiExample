using CompanyEmployees;
using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.Contracts;

namespace TestWebApiExample.Extensions
{
    public static class ServiceExtensions
    {
        //If we want to send requests from a different domain to our application,
        //configuring CORS is mandatory
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod() //allows all HTTP methods
            .AllowAnyHeader()
            .WithExposedHeaders("X-Pagination"));
        });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        {

        });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config => config.OutputFormatters.Add(new
            CsvOutputFormatter()));

    }
}
