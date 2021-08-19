using AutoMapper;
using britanicoCore.Interfaces;
using britanicoCore.Services;
using britanicoCore.Tools;
using britanicoDb.Data;
using britanicoDb.Filters;
using britanicoDb.Interfaces;
using britanicoDb.Repositories;
using britanicoDb.Services;
using britanicoDb.Tools;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace britanicoApi
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
            //debe ir antes de mvc
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Authentication:Issuer"],
                        ValidAudience = Configuration["Authentication:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                    };
                });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContexts(Configuration);
            services.AddServices();

            services.AddControllers(opt =>
            {
                opt.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            })
                .ConfigureApiBehaviorOptions(opt =>
                {
                    //     opt.SuppressModelStateInvalidFilter = true;
                });


            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));
            services.Configure<PasswordOptions>(Configuration.GetSection("PasswordOptions"));

            services.AddMvc(opt =>
            {
                opt.Filters.Add<ValidationFilter>();
            })
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                });
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

            //como uso jwt, authentication debe ir primero
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
