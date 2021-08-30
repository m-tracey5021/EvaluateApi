using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using EvaluateApi.Models;
using EvaluateApi.Models.Context;
using EvaluateApi.Repositories;
using EvaluateApi.Repositories.Interfaces;
using EvaluateApi.Managers;
using EvaluateApi.Managers.Interfaces;

namespace EvaluateApi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = "Server=localhost;Database=Evaluate;User Id=SA;Password=!ty_W0rd53cUr;";

            services.AddDbContext<EvaluateContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IExpressionRepository, ExpressionRepository>();

            services.AddScoped<IParsingManager, ParsingManager>();

            services.AddScoped<IComparisonManager, ComparisonManager>();

            services.AddScoped<IEvaluationManager, EvaluationManager>();

            services.AddScoped<IManipulationManager, ManipulationManager>();

            services.AddScoped<IRulesManager, RulesManager>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                builder =>
                                {
                                    builder.WithOrigins("http://localhost:8080")
                                    .AllowAnyHeader();
                                });
            });
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
