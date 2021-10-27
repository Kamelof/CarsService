using CarsBuisnessLayer.Interfaces;
using CarsBuisnessLayer.MapperProfiles;
using CarsBuisnessLayer.Services;
using CarsCore.Options;
using CarsDataLayer;
using CarsDataLayer.Interfaces;
using CarsDataLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CarsPresentationLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFCoreContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:default"]));

            services.AddHttpContextAccessor();

            services.Configure<AuthOptions>(Configuration.GetSection(nameof(AuthOptions)));
            services.Configure<SmtpOptions>(Configuration.GetSection(nameof(SmtpOptions)));

            AuthOptions authOptions = Configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>();
            services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey
                            (System.Text.Encoding.ASCII.GetBytes(authOptions.SecretKey)),
                        ValidateIssuerSigningKey = true
                    };
                });

            Assembly[] assemblies = new[]
            {
                Assembly.GetAssembly(typeof(CarsProfile))
            };

            services.AddAutoMapper(assemblies);

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICarsRepository, CarsRepositoryDb>();
            services.AddScoped<ICarsService, CarsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<ISmtpService, SmtpService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarsService", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarsService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}