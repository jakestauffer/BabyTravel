using BabyTravel.Api.MappingProfiles;
using BabyTravel.Api.Middleware;
using BabyTravel.Data.Contexts;
using BabyTravel.Data.Encryption;
using BabyTravel.Data.Repositories;
using BabyTravel.Data.Repositories.Abstractions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;

namespace BabyTravel.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://localhost:7118")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddOpenApiDocument();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<BabyControllerMappingProfile>();
                cfg.AddProfile<UserControllerMappingProfile>();
                cfg.AddProfile<TripControllerMappingProfile>();
            });

            var connectionString = Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException
               ("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<BabyTravelDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBabyRepository, BabyRepository>();
            services.AddScoped<ITripRepository, TripRepository>();

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/Forbidden/";
                });

            services.AddHttpContextAccessor();

            EncryptionHelper.SetEncryptionKey(Configuration["EncryptionKey"]!);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseMiddleware<ErrorResponseMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCookiePolicy(new CookiePolicyOptions()
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            });
        }
    }
}