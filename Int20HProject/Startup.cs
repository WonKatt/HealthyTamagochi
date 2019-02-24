using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using ModelsLogic.IModelLogic;
using ModelsLogic.ModelLogicRealization;

namespace Int20HProject
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            Configuration=new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile(Directory.GetCurrentDirectory()+ "/DbConnection.json")
                .Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<INutritionApi,NutritionApiRequests>();
            services.AddDbContextPool<TeencyBarkerContext>(builder =>
            {
                builder.UseNpgsql(Configuration["ConnectionStrings:TeencyBarker"],
                    conf => conf.MigrationsAssembly("Int20HProject"));
            });
            services.AddTransient<ISearchedFoodLogic,SearchedFoodLogic>();
            services.AddTransient<IUserInfoLogic,UserInfoLogic>();
            services.AddTransient<IUserSearchesLogic,UserSearchesLogic>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
