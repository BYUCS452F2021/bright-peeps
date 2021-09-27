using BrightPeeps.Core.Models;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.AzureSql;
using BrightPeeps.Data.LuceneSearch;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BrightPeeps.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BrightPeeps.Api", Version = "v1" });
            });

            services.AddSingleton<ISqlDataAccessService, AzureSqlDataAccessService>(
                (services) =>
                {
                    var dataAccess = new AzureSqlDataAccessService(
                        connectionString: Configuration["AzureSqlDb:ConnectionString"]
                    );

                    dataAccess.TestConnection()
                        .GetAwaiter().GetResult(); // Runs async method synchronously.

                    return dataAccess;
                }
            );

            services.AddSingleton<ISearchService<PersonProfile>, PersonSearchService>(
                (services) => new PersonSearchService(
                    personSearchDirectory: Configuration["LuceneSearch:PersonDirectory"]
            ));

            services.AddMediatR(typeof(Startup).Assembly);

            services.AddCors(cors => cors.AddPolicy("Permissive", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bright Peeps API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("Permissive");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
