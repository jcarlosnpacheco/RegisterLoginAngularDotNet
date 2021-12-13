using Business.Entity;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RegisterLoginAPI.Auth;
using RegisterLoginAPI.Business.Entity;
using RegisterLoginAPI.Business.Interfaces.Auth;
using RegisterLoginAPI.Business.Interfaces.Queries;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using RegisterLoginAPI.Infra.Data.Context;
using RegisterLoginAPI.Infra.Data.Queries;
using RegisterLoginAPI.Infra.Data.Queries.Dapper.Context;
using RegisterLoginAPI.Infra.Data.Repositories;
using System;
using System.Text;

namespace RegisterLoginAPI.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
             * Transient objects are always different; a new instance is provided to every controller and every service.
             * Scoped objects are the same within a request, but different across different requests.
             * Singleton objects are the same for every object and every request.*/

            services.AddCors();
            services.AddSingleton(Configuration);
            services.AddControllers();

            #region Auth

            //https://balta.io/artigos/aspnet-5-autenticacao-autorizacao-bearer-jwt
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["UserKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddTransient<ITokenService, TokenService>();

            #endregion Auth

            #region MediatR

            //reference Handler in other class library
            var assembly = AppDomain.CurrentDomain.Load("Business");
            services.AddMediatR(assembly);

            #endregion MediatR

            #region repository

            services.AddTransient<IGenericRepository<RegisterLogin>, RegisterLoginRepository>();
            services.AddTransient<IGenericRepository<LoginType>, LoginTypeRepository>();
            services.AddTransient<IGenericRepository<User>, UserRepository>();

            #endregion repository

            #region Swagger

            services.AddSwaggerGen(options =>
            {
                var url = "https://github.com/jcarlosnpacheco";
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Register Login API",
                        Version = "v1",
                        Description = "API Sample for register yours logins with ASP.NET Core",
                        Contact = new OpenApiContact
                        {
                            Name = "João Pacheco",
                            Url = new Uri(url)
                        }
                    });

                /*this trick get bearer token into header*/
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });

            #endregion Swagger

            #region DbContext

            services.AddEntityFrameworkNpgsql()
             .AddDbContext<DBRegisterLoginContext>(
                options => options.UseNpgsql(Configuration.GetConnectionString("RegisterLoginDB"),
                                            b => b.MigrationsAssembly("RegisterLoginAPI"))
             );

            #endregion DbContext

            #region Dapper

            services.AddSingleton<DapperContext>();

            #endregion Dapper

            #region Queries

            services.AddTransient<IRegisterLoginQueries, RegisterLoginQueries>();
            services.AddTransient<ILoginTypeQueries, LoginTypeQueries>();
            services.AddTransient<IUserQueries, UserQueries>();

            #endregion Queries
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Register Login API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            #region Auth

            app.UseAuthentication();
            app.UseAuthorization();

            #endregion Auth

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}