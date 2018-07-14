using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using GamesProject.DataAccessLayer.EntitiFramework;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using GamesProject.Models;
using GamesProject.DataAccessLayer.Interfaces;
using GamesProject.DataAccessLayer.Repositories;
using GamesProject.BusinessLogicLayer.Interfaces;
using GamesProject.BusinessLogicLayer.Service;

namespace GamesProject
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

            string connectionString = Configuration.GetSection("ConnectionStrings")["DatabaseAccess"];

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(options =>
            //        {
            //            options.RequireHttpsMetadata = false;
            //            options.TokenValidationParameters = new TokenValidationParameters
            //            {
                            
            //                ValidateIssuer = true,
            //                ValidIssuer = AuthOptions.ISSUER,

            //                ValidateAudience = true,
            //                ValidAudience = AuthOptions.AUDIENCE,

            //                ValidateLifetime = true,

            //                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            //                ValidateIssuerSigningKey = true,
            //            };
            //        });

            

            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper();
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseAuthentication();
            app.UseStatusCodePages();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
