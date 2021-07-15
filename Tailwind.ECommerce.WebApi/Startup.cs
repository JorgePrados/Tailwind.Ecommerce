using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.Interface;
using Tailwind.Ecommerce.Application.Services;
using Tailwind.Ecommerce.CrossCutting.Common;
using Tailwind.Ecommerce.Domain.Core;
using Tailwind.Ecommerce.Domain.Interface;
using Tailwind.Ecommerce.Infrastructure.Data;
using Tailwind.Ecommerce.Infrastructure.Interface;
using Tailwind.Ecommerce.Infrastructure.Repository;
using Tailwind.ECommerce.WebApi.Helpers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Tailwind.ECommerce.WebApi
{
    public class Startup
    {
        readonly string myPolicy = "policyApiEcommerce";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddCors(options => options.AddPolicy(this.myPolicy, builder => builder.AllowAnyOrigin()
                                                                                           .AllowAnyHeader()
                                                                                           .AllowAnyMethod()));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);


            var appSettingsSection = Configuration.GetSection("Config");

            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddSingleton<IConfiguration>(this.Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<IClientLogic, ClientLogic>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<ICategoryLogic, CategoryLogic>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IClientUserServices, ClientUserServices>();
            services.AddScoped<IClientUserLogic, ClientUserLogic>();
            services.AddScoped<IClientUserRepository, ClientUserRepository>();

            services.AddScoped<IOrderHeaderServices, OrderHeaderServices>();
            services.AddScoped<IOrderHeaderLogic, OrderHeaderLogic>();
            services.AddScoped<IOrderHeaderRepository, OrderHeaderRepository>();

            services.AddScoped<IOrderLineServices, OrderLineServices>();
            services.AddScoped<IOrderLineLogic, OrderLineLogic>();
            services.AddScoped<IOrderLineRepository, OrderLineRepository>();

            services.AddScoped<IOrderStateServices, OrderStateServices>();
            services.AddScoped<IOrderStateLogic, OrderStateLogic>();
            services.AddScoped<IOrderStateRepository, OrderStateRepository>();

            services.AddScoped<IPaymentMethodServices, PaymentMethodServices>();
            services.AddScoped<IPaymentMethodLogic, PaymentMethodLogic>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();

            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IProductLogic, ProductLogic>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ITableRepository, TableRepository>();

            services.AddScoped<IColumnTableLogic, ColumnTableLogic>();
            services.AddScoped<IColumnTableRepository, ColumnTableRepository>();

            services.AddScoped<IConfigurationTableRepository, ConfigurationTableRepository>();

            services.AddScoped<IColumnTableManagmentServices, ColumnTableManagmentServices>();
            services.AddScoped<IColumnTableManagmentLogic, ColumnTableManagmentLogic>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var Issuer = appSettings.Issuer;
            var Audience = appSettings.Audience;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userId = int.Parse(context.Principal.Identity.Name);
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = Issuer,
                    ValidateAudience = true,
                    ValidAudience = Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Tailwind Software Technology Services API Market",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://tailwind.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Jorge Prados",
                        Email = "jorgepradospalomo@gmail.com",
                        Url = new Uri("https://tailwind.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://tailwind.com/licence")
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization by API key.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    //BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Ecommerce V1");
            });
            
            app.UseCors(this.myPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseAuthentication();
        }
    }
}
