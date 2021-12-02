using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes_Api.Contracts;
using Heroes_Api.Models;
using Heroes_Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Heroes_Api
{
    public class Startup
    {
        public IConfiguration Configuration;
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HeroesContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:heroesContext"]));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<HeroesContext>();

            services.AddControllers();

            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
            {
                opts.RequireHttpsMetadata = false;
                opts.SaveToken = true;
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["jwtSecret"])),
                    ValidateAudience = true,
                    ValidAudience = Configuration["jwtAudiance"],
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["jwtIssuer"]
                };
                opts.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async ctx =>
                    {
                        var usrmgr = ctx.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
                        var signinmgr = ctx.HttpContext.RequestServices.GetRequiredService<SignInManager<ApplicationUser>>();
                        string userId = ctx.Principal.FindFirst("userId")?.Value;
                        ApplicationUser idUser = await usrmgr.FindByIdAsync(userId);
                        ctx.Principal = await signinmgr.CreateUserPrincipalAsync(idUser);
                    }
                };
            });

            services.AddScoped<ITrainersRepository, TrainersSqlRepository>();
            services.AddScoped<IHeroesRepository, HeroesSqlRepository>();
            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options => {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HeroesContext _context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllers().RequireAuthorization();
            });
            SeedHeroes.Seed(_context);
        }
    }
}
