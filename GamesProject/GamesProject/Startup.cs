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
using Microsoft.AspNetCore.Identity;
using GamesProject.BusinessLogicLayer.DataTransferModels;
using System.Text;

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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["AuthOption:Issuer"],
                        ValidAudience = Configuration["AuthOption:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AuthOption:SigningKey"]))
                    };
                });



            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors();

            services.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork>();

            services.AddScoped<IShellHighScoreService, ShellHighScore>();

            services.AddScoped<IUserService, UserService>();

            var hasher = new PasswordHasher<UserDTM>();
            services.AddSingleton<IPasswordHasher<UserDTM>>(hasher);

            services.AddAutoMapper();
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseStatusCodePages();
            app.UseCors(builder =>  builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
