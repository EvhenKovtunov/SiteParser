using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SiteParser.API.Context;
using SiteParser.API.IRepositories;
using SiteParser.API.Models;
using SiteParser.API.Repositories;

namespace SiteParser.API
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


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IBaseRepository, BaseRepository>();

            var connection = @"Server=DESKTOP-82BC4TF;Database=SiteParser;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<SIteParserContext>
                (options => options.UseSqlServer(connection));
            //SqlConnectionStringBuilder connectionString =
            //new SqlConnectionStringBuilder();
            //connectionString["Data Sourc"] = "DESKTOP-82BC4TF";
            //connectionString["integrated Security"] = true;
            //connectionString["Initial Catalog"] = "SiteParser";

            //services.AddFluentMigratorCore()
            //.ConfigureRunner(
            //builder => builder
            //   .AddSQLite()
            //   .WithGlobalConnectionString("Data Source=DESKTOP-82BC4TF")
            //   .ScanIn(typeof(CreateBaseTable).Assembly).For.Migrations()).AddLogging(lb => lb.AddFluentMigratorConsole())
            //   ;

            //var serviceProvider = services.BuildServiceProvider();

            //var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            //// Run the migrations
            //runner.MigrateUp();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }


    }
}
