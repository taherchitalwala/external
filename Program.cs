using alvazaratAPI53.Repositories;
using alvazaratAPI53.Repositories.Masters;
using alvazaratAPI53.Repositories.specificJamaat;
using Scalar.AspNetCore;
using Serilog;
using System.Text.Json;

namespace alvazaratAPI53
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // ✅ Register DbConnectionBank with configuration dependency
                builder.Services.AddScoped<DbConnectionBank>(sp =>
                    new DbConnectionBank(sp.GetRequiredService<IConfiguration>()));


                // ✅ Register repository
                builder.Services.AddScoped<IallJamaatRepository, allJamaatRepository>();
                builder.Services.AddScoped<IspecificJamaatRepository, specificJamaatRepository>();


                // Add services to the container
                builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    });

                builder.Services.AddOpenApi();
                builder.Services.AddEndpointsApiExplorer();

                var app = builder.Build();

                //if (app.Environment.IsDevelopment())
                //{

                //}

                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("Alvazaratus Saifiyah API V1");
                });

                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
